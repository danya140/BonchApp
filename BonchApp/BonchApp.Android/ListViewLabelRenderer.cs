/*using Android.Content;
using Android.Views;
using BonchApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(ViewCell), typeof(ViewCellTransparent))]
namespace BonchApp.Droid
{
    public class ViewCellTransparent : ViewCellRenderer
    {
        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);
            var listView = parent as Android.Widget.ListView;

            if (listView != null)
            {
                // Disable native cell selection color style - set as *Transparent*
                listView.SetSelector(Android.Resource.Color.HoloOrangeDark);
                listView.CacheColorHint = Android.Graphics.Color.Transparent;
            }

            return cell;
        }
    }
}*/