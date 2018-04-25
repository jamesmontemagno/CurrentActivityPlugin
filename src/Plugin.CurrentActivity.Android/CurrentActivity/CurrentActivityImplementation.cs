using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System;

namespace Plugin.CurrentActivity
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class CurrentActivityImplementation : ICurrentActivity
    {

        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>The activity.</value>
        public Activity Activity
        {
            get => lifecycleListener?.Activity;
            set
            {
                if (lifecycleListener == null)
                    Init(value, null);
            }
        }

        /// <summary>
		/// Activity state changed event handler
		/// </summary>
        public event EventHandler<ActivityEventArgs> ActivityStateChanged;


        internal void RaiseStateChanged(Activity activity, ActivityEvent ev)
            => ActivityStateChanged?.Invoke(this, new ActivityEventArgs(activity, ev));
       

		ActivityLifecycleContextListener lifecycleListener;


		/// <summary>
		/// Initialize current activity with application
		/// </summary>
		/// <param name="application">The main application</param>
        public void Init(Application application)
        {
			if (lifecycleListener != null)
				return;

            lifecycleListener = new ActivityLifecycleContextListener();
            application.RegisterActivityLifecycleCallbacks(lifecycleListener);
        }

		/// <summary>
		/// Initialize current activity with activity!
		/// </summary>
		/// <param name="activity">The main activity</param>
		/// <param name="bundle">Bundle for activity </param>
        public void Init(Activity activity, Bundle bundle) =>
           Init(activity.Application);
    }

    [Preserve(AllMembers = true)]
    class ActivityLifecycleContextListener : Java.Lang.Object, Application.IActivityLifecycleCallbacks
    {
        WeakReference<Activity> currentActivity = new WeakReference<Activity>(null);

        public Context Context =>
            Activity ?? Application.Context;

        public Activity Activity =>
            currentActivity.TryGetTarget(out var a) ? a : null;

		CurrentActivityImplementation Current =>
			(CurrentActivityImplementation)(CrossCurrentActivity.Current);

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
			currentActivity.SetTarget(activity);
			Current.RaiseStateChanged(activity, ActivityEvent.Created);
		}

        public void OnActivityDestroyed(Activity activity)
		{
			Current.RaiseStateChanged(activity, ActivityEvent.Destroyed);
		}

        public void OnActivityPaused(Activity activity)
        {
            currentActivity.SetTarget(null);
			Current.RaiseStateChanged(activity, ActivityEvent.Paused);
		}

        public void OnActivityResumed(Activity activity)
        {
            currentActivity.SetTarget(activity);
			Current.RaiseStateChanged(activity, ActivityEvent.Resumed);
		}

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
			Current.RaiseStateChanged(activity, ActivityEvent.SaveInstanceState);
		}

        public void OnActivityStarted(Activity activity)
		{
			Current.RaiseStateChanged(activity, ActivityEvent.Started);
		}

        public void OnActivityStopped(Activity activity)
		{
			Current.RaiseStateChanged(activity, ActivityEvent.Stopped);
		}
    }
}