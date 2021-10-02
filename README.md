# XamarinPosed

Write Xposed module with Xamarin and C# 🐱‍💻

This project is still in development, but it works - you can try it now!

I only test it on VirtualXposed. If it won't work on Xposed, please help me fix it.

## Limitations
The app startup time would be slightly longer because of mono initialization. But hey, who cares? Welcome to the .NET world.

For VirtualXposed: The module app will be unable to open directly after you enable it as a Xposed module. 
That's because the same native libraries are already loaded by the module's ClassLoader, so the APK's ClassLoader won't be able to use them.

## Usage
Please use the newest stable version of Visual Studio and Xamarin.

Clone this repo and implement your `InitZygote`, `HandleLoadPackage`, `HandleInitPackageResources` in `XamarinPosed\XamarinPosed\Loader.cs`.

(`HandleInitPackageResources` is disabled by default. To enable it, remove "VXP" from XaraminPosed Properties - Conditional Compilation Symbols)

Build `XamarinPosed` project with release config. It will be a Xposed module apk. 

## Demo
Build all projects with Release config. 

Install both `XamarinPosed` and `Xamarin.Posed.Demo` to your phone. Enable the `Xamarin.Posed` module. (Don't try to open it after enabled.)

Open `Xamarin.Posed.Demo` ([Monarch Solutions](https://github.com/MonarchSolutions) logo), click the FloatingActionButton (bottom-right), then click `ACTION`.

If the  `Xamarin.Posed` module is working, you will get a toast showing `All your base are belong to us!`. Otherwise, nothing happens.

<img src="https://github.com/UlyssesWu/XamarinPosed/blob/main/img/XamarinPosed_demo.jpg" width="500">

## Hints
### How to change xposed module name?
XamarinPosed Project Properties - Android Manifest - change package name to whatever you want

### How to enable Resource hook?
Since resource hook is not supported by VirtualXposed, it's disabled by default. To enable it:

XamarinPosed Project Properties - Build - Conditional Compilation Symbols - remove "VXP"

## Related Projects

[Xamarin.Android.Xposed](https://github.com/Redth/Xamarin.Android.Xposed)

This project is a good start for research, however it won't work, since it only get over the very first problem - Jar Binding.

There is still a lot of work to do after that, as you can learn from XamarinPosed.

[VirtualXposed](https://github.com/android-hacker/VirtualXposed)

[Xpatch](https://github.com/WindySha/Xpatch)

## License

XamarinPosed is licensed under **MIT** license.

------

by Ulysses (wdwxy12345@gmail.com)
