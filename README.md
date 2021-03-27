# XamarinPosed

Write Xposed module with Xamarin and C# 🐱‍💻

This project is still in development, but it works - you can try it now!

I only test it on VirtualXposed. If it won't work on Xposed, please help me fix it.

## Limitations

The module app will be unable to open directly after you enable it as a Xposed module. 
That's because the same native libraries are already loaded by the module's ClassLoader, so the APK's ClassLoader won't be able to use them.

Still looking for a solution.

The app startup time would be slightly longer because of mono initialization. But hey, who cares? Welcome to the .NET world.

## Usage
Please use the newest stable version of Visual Studio and Xamarin.

Clone this repo and implement your `InitZygote`, `HandleLoadPackage`, `HandleInitPackageResources` in `XamarinPosed\XamarinPosed\Loader.cs`.

Build `XamarinPosed` project with release config. It will be a Xposed module apk. 

## Demo

Build all projects with Release config. 

Install both `XamarinPosed` and `Xamarin.Posed.Demo` to your phone. Enable the `Xamarin.Posed` module. (Don't try to open it after enabled.)

Open `Xamarin.Posed.Demo` ([Monarch Solutions](https://github.com/MonarchSolutions) logo), click the FloatingActionButton (bottom-right), then click `ACTION`.

If the  `Xamarin.Posed` module is working, you will get a toast showing `All your base are belong to us!`. Otherwise, nothing happens.

<img src="https://github.com/UlyssesWu/XamarinPosed/blob/main/img/XamarinPosed_demo.jpg" width="500">

## Related Projects

[Xamarin.Android.Xposed](https://github.com/Redth/Xamarin.Android.Xposed)

This project is a good start for research, however it won't work, since it only get over the very first problem - Jar Binding.

There is still a lot of work to do after that, as you can learn from XamarinPosed.

## License

XamarinPosed is licensed under **MIT** license.

------

by Ulysses (wdwxy12345@gmail.com)
