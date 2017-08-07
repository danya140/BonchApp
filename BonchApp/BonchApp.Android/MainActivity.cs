using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BonchApp.Droid
{
	[Activity (Label = "BonchApp", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
            
            TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new BonchApp.App ());
        }
       
    }
    /* bool doubleBackToExitPressedOnce = false;
    public override void OnBackPressed()
    {

        if (doubleBackToExitPressedOnce)
        {
            base.OnBackPressed();
            Java.Lang.JavaSystem.Exit(0);
            return;
        }
        bool LastPageCheck = true;    //тут надо умудриться сделать проверку на последнюю страницу
        if (LastPageCheck == true)    //в файле MasterDetailPage1.xaml.cs есть код, который нужно соединить с этой помойкой
        {
            this.doubleBackToExitPressedOnce = true;
            Toast.MakeText(this, "Нажмите еще раз для выхода!", ToastLength.Short).Show();

            new Handler().PostDelayed(() =>
            {
                doubleBackToExitPressedOnce = false;
            }, 2000);
        }*/
}


