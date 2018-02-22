CurrentActivity Readme

This plugin provides base functionality for Plugins for Xamarin to gain access to the application's main Activity.

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

If you already have an "Application" class in your project implement: Application.IActivityLifecycleCallbacks on your Application, and make changes suggested in step 3

Here is a final version of what yours may look like:

```
using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace $rootnamespace$
{
	//Do not delete thise file! It was here because plugins depend on it. 
	//If you have an existing Application class you can merge the two together
	//if you have existing assembly:Application, you can remove them.
#if DEBUG
	[Application(Debuggable = true)]
#else
	[Application(Debuggable = false)]
#endif
    public partial class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

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

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}
```

Read more - https://montemagno.com/access-the-current-android-activity-from-anywhere/
