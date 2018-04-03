using System;
using Android.App;


namespace Plugin.CurrentActivity
{
    public class ActivityEventArgs : EventArgs
    {
        public ActivityEventArgs(Activity activity, ActivityEvent ev)
        {
            Activity = activity;
            Event = ev;
        }


        public Activity Activity { get; }
        public ActivityEvent Event { get; }
    }
}