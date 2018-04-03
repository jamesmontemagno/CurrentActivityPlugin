using System;
using Android.App;

namespace Plugin.CurrentActivity
{
    /// <summary>
    /// Current Activity Interface
    /// </summary>
    public interface ICurrentActivity
    {
        /// <summary>
        /// Gets or sets the activity.
        /// </summary>
        /// <value>The activity.</value>
        Activity Activity { get; set; }

        /// <summary>
        /// Fires when the current activity instance is changing
        /// </summary>
        event EventHandler<Activity> CurrentActivityChanged;

        /// <summary>
        /// Fires when activity state events are fired
        /// </summary>
        event EventHandler<ActivityEventArgs> ActivityStateChanged;

        /// <summary>
        /// Method to fire internal event - NOT MEANT TO BE CALLED BY EXTERNAL CODE
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="ev"></param>
        void RaiseStateChanged(Activity activity, ActivityEvent ev);
    }
}