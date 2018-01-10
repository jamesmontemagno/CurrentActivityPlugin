CurrentActivity Readme

This plugin provides base functionality for Plugins for Xamarin to gain access to the applications main activity.

# Gettting Started

When plugin is installed, follow the below steps to initialise in your project:

1. Add a new C# class file in you project called "MainApplication.cs". 
   Name the class `MainApplication`, and inherit it from `Application` and `Application.IActivityLifecycleCallbacks`.
   This file exposes an Android "Application" that registers for Activity changes.
2. Add `Application` attribute, this will generate `application` element if the AndroidManifest.xml file
3. Then set: 
    CrossCurrentActivity.Current.Activity = activity;

    in the OnActivityCreated, OnActivityStarted, OnActivityResumed methods

    Additionally:
    public override void OnCreate()
    {
        base.OnCreate();
        RegisterActivityLifecycleCallbacks(this);
    }

    public override void OnTerminate()
    {
        base.OnTerminate();
        UnregisterActivityLifecycleCallbacks(this);
    }

If you already have an "Application" class in your project implement: Application.IActivityLifecycleCallbacks on your Application,
and make changes suggested in step 3

Read more - https://montemagno.com/access-the-current-android-activity-from-anywhere/