//by Ulysses, wdwxy12345@gmail.com
package xamarin.posed;

import java.util.Locale;
import java.io.File;
import mono.android.BuildConfig;
import mono.android.DebugRuntime;
import mono.android.Runtime;
import mono.android.app.ApplicationRegistration;
import mono.android.app.NotifyTimeZoneChanges;
import mono.MonoPackageManager_Resources;
import android.os.Build;
import android.os.Environment;
import android.util.Log;

public class XamarinPosedLoader
	//extends java.lang.Object
	implements
		//mono.android.IGCUserPeer,
		de.robv.android.xposed.IXposedHookLoadPackage,
		de.robv.android.xposed.IXposedHookZygoteInit
		de.robv.android.xposed.IXposedHookInitPackageResources
{
/** @hide */
	public xamarin.posed.Main_Loader _loader;
	public boolean isInited = false;
	static {}

	public XamarinPosedLoader ()
	{
		super ();
	}

	public void handleLoadPackage (de.robv.android.xposed.callbacks.XC_LoadPackage.LoadPackageParam p0)
	{
		if (isInited && _loader != null)
		{
			_loader.handleLoadPackage(p0);
		}
	}

	public void initZygote (de.robv.android.xposed.IXposedHookZygoteInit.StartupParam p0)
	{
		if (!isInited)
		{
			String modulePath = p0.modulePath; // /data/user/0/io.va.exposed/virtual/data/app/{package}/base.apk
			Locale locale = Locale.getDefault();
			String localeStr = locale.getLanguage() + "-" + locale.getCountry();

			String f1 = modulePath.replaceFirst("/app/", "/user/0/");
			String filesDir = f1.substring(0, f1.lastIndexOf("/"));
			//String filesDir = context.getFilesDir().getAbsolutePath(); // /data/user/0/io.va.xposed/virtual/data/user/0/{package}/
			String packageName = filesDir.substring(filesDir.lastIndexOf("/") + 1);

			String cacheDir = filesDir + "/" + "cache";
			//String cacheDir = context.getCacheDir().getAbsolutePath(); // filesDir + "cache"
			String dataAppDir = modulePath.substring(0, modulePath.lastIndexOf("/"));
			String nativeLibraryPath = dataAppDir + "/lib"; // getNativeLibraryPath(context);
			//tring nativeLibraryPath = getNativeLibraryPath(context); //{baseApkDir}/../lib
			
			ClassLoader classLoader = this.getClass().getClassLoader();
			//TODO: hook context.getClassLoader() and replaced to this classLoader
			//ClassLoader classLoader = de.robv.android.xposed.XposedBridge.BOOTCLASSLOADER;
            File externalStorageDirectory = Environment.getExternalStorageDirectory();

			String externalOverrridePath = new File(externalStorageDirectory, "Android/data/" + packageName + "/files/.__override__").getAbsolutePath();
			String externalOverrridePathLegacy = new File(externalStorageDirectory, "../legacy/Android/data/" + packageName + "/files/.__override__").getAbsolutePath();

			String nativeLibraryPath2 = nativeLibraryPath; //getNativeLibraryPath(applicationInfo);

			String[] sourceDirs = new String[1]; //append ApplicationInfo.splitPublicSourceDirs if needed
			sourceDirs[0] = modulePath;

			String[] initParams = {filesDir, cacheDir, nativeLibraryPath};
			String[] externalOverrrideParams = {externalOverrridePath, externalOverrridePathLegacy};

			if (BuildConfig.Debug) 
			{
				System.loadLibrary("xamarin-debug-app-helper");
				DebugRuntime.init(sourceDirs, nativeLibraryPath2, initParams, externalOverrrideParams);
			} 
			else 
			{
				System.loadLibrary("monosgen-2.0");
			}
			System.loadLibrary("xamarin-app");
			try 
			{
				System.loadLibrary("mono-native");
			} 
			catch (UnsatisfiedLinkError e) 
			{
				Log.i("monodroid", "Failed to preload libmono-native.so (may not exist), ignoring", e);
			}

			System.loadLibrary("monodroid");
			Runtime.initInternal(localeStr, sourceDirs, nativeLibraryPath2, initParams, classLoader, externalOverrrideParams, MonoPackageManager_Resources.Assemblies, Build.VERSION.SDK_INT, isEmulator());
			ApplicationRegistration.registerApplications();

			_loader = new xamarin.posed.Main_Loader();
			//_loader = new xamarin.posed.Main_Loader(modulePath, packageName);
			isInited = true;
		}

		if (isInited && _loader != null)
		{
			_loader.initZygote (p0);
		}		
	}

	public void handleInitPackageResources (de.robv.android.xposed.callbacks.XC_InitPackageResources.InitPackageResourcesParam p0)
	{
		if (isInited && _loader != null)
		{
			_loader.handleInitPackageResources(p0);
		}
	}
	
    static boolean isEmulator() {
        String str = Build.HARDWARE;
        return str.contains("ranchu") || str.contains("goldfish");
    }
}
