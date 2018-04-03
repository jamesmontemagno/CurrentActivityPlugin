using System;
using Android.App;


namespace Plugin.CurrentActivity
{
    public class ActivityEventArgs : EventArgs
	{
		internal ActivityEventArgs(Activity activity, ActivityEvent ev)
        {
            Event = ev;
			Activity = activity;
        }
        
        public ActivityEvent Event { get; }
		public Activity Activity { get; }
	}
}