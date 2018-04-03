using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Plugin.CurrentActivity;

namespace CurrentActivityTest
{
	[Application]
	public class MainApplication : Application
	{
		public MainApplication(IntPtr handle, JniHandleOwnership transer)
		  : base(handle, transer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			CrossCurrentActivity.Current.Init(this);
			CrossCurrentActivity.Current.ActivityStateChanged += Current_ActivityStateChanged;
		}

		private void Current_ActivityStateChanged(object sender, ActivityEventArgs e)
		{
			Toast.MakeText(Application.Context, $"Activity Changed: {e.Activity.LocalClassName} -  {e.Event}", ToastLength.Short).Show();
			
		}
	}
}