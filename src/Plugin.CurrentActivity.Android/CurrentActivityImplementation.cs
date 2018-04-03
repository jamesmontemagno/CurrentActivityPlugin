using Android.App;
using System;


namespace Plugin.CurrentActivity
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class CurrentActivityImplementation : ICurrentActivity
    {
        Activity activity;


        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>The activity.</value>
        public Activity Activity
        {
            get => this.activity;
            set
            {
                activity = value;
                CurrentActivityChanged?.Invoke(this, value);
            }
        }


        public event EventHandler<Activity> CurrentActivityChanged;
        public event EventHandler<ActivityEventArgs> ActivityStateChanged;


        public void RaiseStateChanged(Activity activity, ActivityEvent ev)
            => ActivityStateChanged?.Invoke(this, new ActivityEventArgs(activity, ev));
    }
}