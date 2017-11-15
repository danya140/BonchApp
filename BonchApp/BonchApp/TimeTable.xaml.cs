using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BonchApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimeTable : ContentPage
	{
        private CookieContainer cookieJar;
        List<Lesson> lessons;
        DateTime date;
        int rowMultiplier = 4;


        public TimeTable ()
		{
			InitializeComponent ();

            date = DateTime.Now;
            
            makeLayout(getTimetableForDate(date));
		}

        public void makeLayout(List<JToken> timetable)
        {
            root.Children.Clear();
            lessons = new List<Lesson>();

            Grid grid = new Grid();

            //TODO: Fix size first row

            foreach (JToken t in timetable)
            {
                lessons.Add(t.ToObject<Lesson>());
            }

            grid.Children.Add(new Label
            {
                Text = "Неделя № ???",
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.FromHex("F9F9F9")
            }, 0, 2, 0, 1*rowMultiplier);

            StackLayout control = new StackLayout();

            control.Orientation = StackOrientation.Horizontal;
            control.BackgroundColor = Color.FromHex("F9F9F9");

            Button previousDay = new Button();
            previousDay.Text = "<";
            previousDay.Clicked += delegate { makeLayout(getTimetableForDate(date)); };


            control.Children.Add(previousDay);

            control.Children.Add(new Label
            {
                Text = date.ToString("d MMMM"),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                MinimumWidthRequest = 100,
                BackgroundColor = Color.FromHex("F9F9F9")
            });

            Button nextDay = new Button();
            nextDay.Text = ">";
            nextDay.Clicked += delegate { makeLayout(getTimetableForDate(date.AddDays(1))); };

            control.Children.Add(nextDay );

            grid.Children.Add(control, 2, 6, 0, 1 * rowMultiplier);
            

            //TODO: rewrite with row deffinition for all rows
            int i = 2;
            foreach(Lesson lesson in lessons)
            {

                grid.Children.Add(new Label
                {
                    Text = lesson.getTime() + "\n" + lesson.lecture_hall,
                    TextColor = Color.FromHex("2A3035"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.White
                    
                },0,2, (i - 1) * rowMultiplier, i * rowMultiplier);

                grid.Children.Add(new Label
                {
                    Text = lesson.lesson_name + "\n" + lesson.teacher_name,
                    TextColor = Color.FromHex("2A3035"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.FromHex("FFFFFF")
                },2, 6, (i - 1)*rowMultiplier, i*rowMultiplier);

                grid.Children.Add(new Label
                {
                    Text = lesson.typeToString(),
                    TextColor = Color.FromHex("2A3035"),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.FromHex(selectColor(lesson.lesson_type))
                }, 5, 6, (i - 1)*rowMultiplier, ((i - 1) * rowMultiplier)+1);

                //grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

                i++;
            }

            //Some costyl for border creating
            grid.RowSpacing = 1d;
            grid.ColumnSpacing = 1d;
            grid.BackgroundColor = Color.FromHex("D0D2D3");

            

            root.Children.Add(grid);
            
        }

        protected string selectColor(int type)
        {
            switch (type)
            {
                case 1:
                    return "7FC6DD";
                case 2:
                    return "BDEF6F";
                case 3:
                    return "F2E868";
                default:
                    return "F9F9F9";
            }
        }

        public List<JToken> getTimetable()
        {
            string url = "http://194.87.111.65/?file=study/timetable";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.CookieContainer = httpGetCookie();
            request.Accept = "text/json";

            var response = (HttpWebResponse)request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            JObject obj = JObject.Parse(stream.ReadToEnd());
            var code = int.Parse(obj.First.Values().ToList()[0].ToString());
            if (code == 256)
            {
                return obj.Children().ElementAt(1).ToList()[0].Children().ToList()[0].Children().ToList();
            }
            else { return null; }
        }

        public List<JToken> getTimetableForDate(DateTime date)
        {
            string url = "http://194.87.111.65/?file=study/timetable&func=byDay&day=2017-10-6";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.CookieContainer = httpGetCookie();
            request.Accept = "text/json";

            var response = (HttpWebResponse)request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            JObject obj = JObject.Parse(stream.ReadToEnd());
            var code = int.Parse(obj.First.Values().ToList()[0].ToString());
            if (code == 256)
            {
                return obj.Children().ElementAt(1).ToList()[0].Children().ToList()[0].Children().ToList();
            }
            else { return null; }
        }

        //get Cookie after login
        public CookieContainer httpGetCookie()
        {
            string url = "http://194.87.111.65/?file=User/login&class=login&func=byHash&u_hash=" + Application.Current.Properties["hash"] as string + "&ud_hash=92c88f1b4d46d72883217e62bc1d1610";
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
        

    }
}