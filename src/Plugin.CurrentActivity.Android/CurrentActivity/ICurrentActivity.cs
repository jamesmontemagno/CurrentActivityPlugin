using System;
using Android.App;
using Android.Content;
using Android.OS;

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
		/// Gets the current Context.
		/// </summary>
		/// <value>The activity.</value>
		Context Context { get; }

		/// <summary>
		/// Fires when activity state events are fired
		/// </summary>
		event EventHandler<ActivityEventArgs> ActivityStateChanged;

		/// <summary>
		/// Initialize Current Activity Plugin with Application
		/// </summary>
		/// <param name="application"></param>
		void Init(Application application);

		/// <summary>
		/// Initialize the current activity with activity and bundle
		/// </summary>
		/// <param name="activity"></param>
		/// <param name="bundle"></param>
		void Init(Activity activity, Bundle bundle);
	}
}