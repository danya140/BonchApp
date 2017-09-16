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
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Xamarin.Forms;

namespace BonchApp.Droid
{
    class FontRendererButton
    {
        public class CustomLabelRenderer : LabelRenderer
        {

            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
                var label = (Android.Widget.Button)Control; // for example
                Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "RobotoLight.ttf");  // font name specified here
                label.Typeface = font;
            }

        }
       
    }
}