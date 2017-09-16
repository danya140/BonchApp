using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BonchApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage1Master : ContentPage
    {
       
        public ListView ListView;
        private CookieContainer cookieJar;

        public MasterDetailPage1Master()
        {
           
            InitializeComponent();

            BindingContext = new MasterDetailPage1MasterViewModel();
            ListView = MenuItemsListView;

            //try get full name from server
            //use try/catch because there are no ways to check internet connection without additional packages
            try
            {
                fio.Text = getName();

            }
            catch (Exception e)
            {
                fio.Text = "";
            }
        }

        public string getName()
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

                string firstName = infoJson.Values().ToList()[3].ToString();
                string lastName = infoJson.Values().ToList()[4].ToString();

                return firstName+ " " + lastName +" ";

            } else { return ""; }

        }

        //get Cookie after login
        public CookieContainer httpGetCookie()
        {

            string url = "http://194.87.111.65/?file=User/login&class=login&func=byHash&u_hash=8f615452c41e19d543f0b515d5078df6&ud_hash=92c88f1b4d46d72883217e62bc1d1610";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            //add cookie container because request dont have it by default
            cookieJar = new CookieContainer();
            request.CookieContainer = cookieJar;

            //TODO: add exception when response code != 6 or 4 same in AboutMe.xaml.cs
            var response = (HttpWebResponse)request.GetResponse();
            StreamReader srt = new StreamReader(response.GetResponseStream());

            var text = srt.ReadToEnd();

            //TODO: save to file cause expire date too long
            return cookieJar;

        }

        class MasterDetailPage1MasterViewModel : INotifyPropertyChanged
        {

            public ObservableCollection<MasterDetailPage1MenuItem> MenuItems { get; set; }

            public MasterDetailPage1MasterViewModel()
            {

                MenuItems = new ObservableCollection<MasterDetailPage1MenuItem>(new[]
                {
                    new MasterDetailPage1MenuItem { Id = 0, Title = "Новости" },
                    new MasterDetailPage1MenuItem { Id = 1, Title = "Уведомления" },
                    new MasterDetailPage1MenuItem { Id = 2, Title = "Справочник и навигация" },
                    new MasterDetailPage1MenuItem { Id = 3, Title = "Файлы группы" },
                    new MasterDetailPage1MenuItem { Id = 4, Title = "Студгородок" },
                    new MasterDetailPage1MenuItem { Id = 5, Title = "Опросы" },
                    new MasterDetailPage1MenuItem { Id = 6, Title = "О себе", TargetType = typeof(AboutMe) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion

        }
    }
}
