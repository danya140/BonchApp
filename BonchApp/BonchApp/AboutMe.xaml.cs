using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Newtonsoft.Json.Linq;

namespace BonchApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutMe : ContentPage
	{

        CookieContainer cookieJar;


        public AboutMe ()
		{
			InitializeComponent ();

            try
            {
                getAbout();
            }
            catch (Exception e) { }
            
            
		}

        public void getAbout()
        {
            string url = "http://194.87.111.65/index.php?file=User/info";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.CookieContainer = httpGetCookie();
            request.Accept = "text/json";

            var response = (HttpWebResponse)request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            var txt = stream.ReadToEnd();

            JObject obj = JObject.Parse(txt);
            var code = int.Parse(obj.First.Values().ToList()[0].ToString());
            if (code == 8)
            {
                var infoJson = obj.Children().ElementAt(1).Values().ToList()[0];

                GroupName.Text = infoJson.Values().ToList()[2].ToString();
                FirstName.Text = infoJson.Values().ToList()[3].ToString();
                LastName.Text = infoJson.Values().ToList()[4].ToString();
                Birthday.Text = infoJson.Values().ToList()[5].ToString();
            }

        }

        //get Cookie after login
        public CookieContainer httpGetCookie()
        {
            string url = "http://194.87.111.65/?file=User/login&class=login&func=byHash&u_hash=8f615452c41e19d543f0b515d5078df6&ud_hash=92c88f1b4d46d72883217e62bc1d1610";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));

            cookieJar = new CookieContainer();
            request.CookieContainer = cookieJar;

            var response =(HttpWebResponse) request.GetResponse();
            StreamReader srt = new StreamReader(response.GetResponseStream());

            var text = srt.ReadToEnd();

            //TODO: save to file cause expire date too long
            return cookieJar;
            
        }
    }
}