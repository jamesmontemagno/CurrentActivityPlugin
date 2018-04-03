using System;


namespace Plugin.CurrentActivity
{
    public enum ActivityEvent
    {
        Created,
        Resumed,
        Paused,
        Destroyed,
		SaveInstanceState,
        Started,
        Stopped
	}
}