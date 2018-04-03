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
            CrossCurrentActivity.Current.RaiseStateChanged(activity, ActivityEvent.Created);
        }

        public void OnActivityDestroyed(Activity activity)
        {
            CrossCurrentActivity.Current.RaiseStateChanged(activity, ActivityEvent.Destroyed);
        }

        public void OnActivityPaused(Activity activity)
        {
            CrossCurrentActivity.Current.RaiseStateChanged(activity, ActivityEvent.Paused);
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
            CrossCurrentActivity.Current.RaiseStateChanged(activity, ActivityEvent.Resumed);
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
