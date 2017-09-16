/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using BonchApp.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using System.ComponentModel;
using Android.Graphics;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Support.V7.Graphics.Drawable;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(MyMasterDetailRenderer))]
namespace BonchApp.Droid
{
    public class MyMasterDetailRenderer : MasterDetailPageRenderer
    {
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            for (var i = 0; i < toolbar.ChildCount; i++)
            {
                var imageButton = toolbar.GetChildAt(i) as ImageButton;

                var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;
                if (drawerArrow == null)
                    continue;

                imageButton.SetImageDrawable(Forms.Context.GetDrawable(Resource.Drawable.burger));
            }
        }
    }
}*/