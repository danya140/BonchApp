using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            if (isLoginSuccess())
            {
                await Navigation.PushModalAsync(new MasterDetailPage1());
                Application.Current.MainPage = new MasterDetailPage1();
            }
            else
            {
                Warning.Text = "Логин или пароль не правильный";
            }

        }

        private bool isLoginSuccess()
        {

            string url = "http://194.87.111.65/?file=User/login&func=byPass&username=" + Entry1.Text + "&password=" + Entry2.Text;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            var response = (HttpWebResponse)request.GetResponse();
            StreamReader srt = new StreamReader(response.GetResponseStream());

            var text = srt.ReadToEnd();

            JObject obj = JObject.Parse(text);
            var code = int.Parse(obj.First.Values().ToList()[0].ToString());
            if(code == 6)
            {
                Application.Current.Properties["login"] = Entry1.Text;
                Application.Current.Properties["pass"] = Entry2.Text;

                var json = obj.Children().ElementAt(1).Values().ToList()[0];
                Application.Current.Properties["hash"] = json.Values().ToList()[0].ToString();
                return true;
            }
            else
            {
                return false;
            }

            

        }
    }
}
