using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BonchApp;
using BonchApp.Droid;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Label), typeof(FontRendererLabel))]

namespace BonchApp.Droid
{
    public class FontRendererLabel : LabelRenderer
    {


        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null && Element.FontFamily != null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, "Fonts/RobotoLight.ttf");
            }
        }


    }
}