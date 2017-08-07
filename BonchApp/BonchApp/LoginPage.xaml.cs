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
            Button1.Clicked += LoginButton_Click;
            Entry1.PlaceholderColor = new Color(256, 256, 256, 0.4);
            Entry2.PlaceholderColor = new Color(256, 256, 256, 0.4);
            Entry1.TextColor = Color.White;
            Entry2.TextColor = Color.White;

        }
      

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            // if (LoginSuccess) функция, проверяющяя вход в систему (которой нет :)))))
            //{
            await Navigation.PushModalAsync(new MasterDetailPage1());
            Application.Current.MainPage = new MasterDetailPage1();
            //}

        }
    }
}
