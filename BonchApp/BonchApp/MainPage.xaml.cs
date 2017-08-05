using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BonchApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            Button1.BackgroundColor = new Color(256, 256, 256, 0.7);
            Entry1.PlaceholderColor = Color.LightGray;
            Entry2.PlaceholderColor = Color.LightGray;
		}
	}
}
