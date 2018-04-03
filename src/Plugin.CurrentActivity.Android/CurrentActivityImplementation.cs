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
                this.activity = value;
                this.CurrentActivityChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<Activity> CurrentActivityChanged;
    }
}