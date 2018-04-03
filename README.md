## Current Activity Plugin for Xamarin.Android

This plugin gives developers and library creators easy access to an Android Application’s current Activity that is being displayed.

Want to read about the creation, checkout my [in-depth blog post](http://motzcod.es/post/133609925342/access-the-current-android-activity-from-anywhere).


### Setup
* Available on NuGet: http://www.nuget.org/packages/Plugin.CurrentActivity [![NuGet](https://img.shields.io/nuget/v/Plugin.CurrentActivity.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.CurrentActivity/)
* Install into your Xamarin.Android Client project.

Build Status: ![Build status](https://jamesmontemagno.visualstudio.com/_apis/public/build/definitions/6b79a378-ddd6-4e31-98ac-a12fcd68644c/18/badge)

CurrentActivity Readme

This plugin provides base functionality for Plugins for Xamarin to gain access to the application's main Activity.

# Gettting Started

When plugin is installed, follow the below steps to initialise in your project. There are two ways to initialize this:

## Main/Base Activity Level
1. Simply call the `Init` method on OnCreate
```csharp
CrossCurrentActivity.Current.Init(this, bundle);
```

## Application Level

1. Add a new C# class file in you project called "MainApplication.cs". 
2. Override the OnCreate method and call the `Init` method
```csharp
#if DEBUG
	[Application(Debuggable = true)]
#else
	[Application(Debuggable = false)]
#endif
	public class MainApplication : Application
	{
		public MainApplication(IntPtr handle, JniHandleOwnership transer)
		  : base(handle, transer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			CrossCurrentActivity.Current.Init(this);
		}
	}
```
If you already have an "Application" class in your project simply add the Init call. 

The benefit of adding it at the Application level is to get the first events for the application.



### API Usage

Call **CrossCurrentActivity.Current** from any project or PCL to gain access to APIs.


**Activity**
```
/// <summary>
/// The Current Activity
/// </summary>
Activity Activity { get; set; }
```

That’s it!

**Library Creators**
Simply set this nuget as a dependency of your project to gain access to the current activity. This can be achieved by setting the following in your nuspec:

```
<dependencies>
  <group targetFramework="MonoAndroid10">
    <dependency id="Plugin.CurrentActivity" version="1.0.1"/>
  </group>
</dependencies>
```
