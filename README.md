## Current Activity Plugin for Xamarin.Android

This plugin gives developers and library creators easy access to an Android Application’s current Activity that is being displayed.

Want to read about the creation, checkout my [in-depth blog post](http://motzcod.es/post/133609925342/access-the-current-android-activity-from-anywhere).


### Setup
* Available on NuGet: http://www.nuget.org/packages/Plugin.CurrentActivity [![NuGet](https://img.shields.io/nuget/v/Plugin.CurrentActivity.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.CurrentActivity/)
* Install into your Xamarin.Android Client project.

Build Status: [![Build status](https://ci.appveyor.com/api/projects/status/695dpbplb9x2sbta?svg=true)](https://ci.appveyor.com/project/JamesMontemagno/currentactivityplugin)


### API Usage

Call **CrossCurrentActivity.Current** from any project or PCL to gain access to APIs.


**Activity**
```
/// <summary>
/// The Current Activity
/// </summary>
Activity Activity { get; set; }
```

That’s it! Well not really:

**Application Setup**
When you install this plugin a **MainApplication.cs** is installed into your Android project (This will not happen if your project has package references), otherwise follow the instructons from [_readme.txt_](https://raw.githubusercontent.com/jamesmontemagno/CurrentActivityPlugin/master/nuget/readme.txt) that is installed with the plugin. 

If you already have an Application class then you should copy over the important bits that can be found in the [_readme.txt_](https://raw.githubusercontent.com/jamesmontemagno/CurrentActivityPlugin/master/nuget/readme.txt)



**Library Creators**
Simply set this nuget as a dependency of your project to gain access to the current activity. This can be achieved by setting the following in your nuspec:

```
<dependencies>
  <group targetFramework="MonoAndroid10">
    <dependency id="Plugin.CurrentActivity" version="1.0.1"/>
  </group>
</dependencies>
```
