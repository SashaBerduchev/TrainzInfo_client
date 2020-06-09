using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrainzInfo_client.HttpPost
{

    class Post
    {
        private static string constring;
        static readonly HttpClient client = new HttpClient();
        public Post()
        {
            constring = Config.GetString();
        }
        public static async void Send(string ctr, string act, Window window)
        {
            try
            {
                string constr = constring + ctr + '/' + act;
                HttpResponseMessage response = await client.GetAsync(constr);
                response.EnsureSuccessStatusCode();
                Trace.WriteLine("POST  " + response);
                string responseBody = await response.Content.ReadAsStringAsync();

                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Trace.WriteLine("RESPONSE" + responseBody.ToString());
                var data = JsonConvert.DeserializeObject<List<NewsInfoes>>(responseBody);
                Trace.WriteLine(data.Select(x => x.id + " " + x.NameNews + " " + x.BaseNewsInfo + " " + x.NewsInfoAll));
                (window as MainWindow).listnews.ItemsSource = data.Select(x => x.id + " " + x.NameNews + " " + x.BaseNewsInfo + " " + x.NewsInfoAll).ToList();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }

        }
        public class NewsInfoes
        {
            public int id { get; set; }
            public string NameNews { get; set; }
            public string BaseNewsInfo { get; set; }
            public string NewsInfoAll { get; set; }
            public DateTime DateTime { get; set; }
            public string Imgsrc { get; set; }
            public string user { get; set; }
        }
    }
}
