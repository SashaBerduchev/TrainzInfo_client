using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

using System.ServiceModel.PeerResolvers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrainzInfo_client.WIndows;

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
        public static async void Send(string ctr, string act, Window window, object data = null)
        {
            try
            {
                string constr = constring + ctr + '/' + act;
                if (data != null)
                {
                    var senddata = JsonConvert.SerializeObject(data);
                    Trace.WriteLine("POST " + senddata);
                    var content = new StringContent(senddata);
                    Trace.WriteLine(content);
                    HttpResponseMessage request = await client.PostAsJsonAsync(new Uri(constr), senddata);
                    request.EnsureSuccessStatusCode();
                }
                HttpResponseMessage response = await client.GetAsync(constr);
                response.EnsureSuccessStatusCode();
                Trace.WriteLine("POST  " + response);
                string responseBody = await response.Content.ReadAsStringAsync();

                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                Trace.WriteLine("RESPONSE" + responseBody.ToString());
                
                
                if (ctr == "NewsInfo")
                {
                    List<NewsInfoes> news = JsonConvert.DeserializeObject<List<NewsInfoes>>(responseBody);
                    Trace.WriteLine(news.Select(x => x.id + " " + x.NameNews + " " + x.BaseNewsInfo + " " + x.NewsInfoAll));
                    (window as MainWindow).listnews.ItemsSource = news.Select(x => x.id + " " + x.NameNews + " " + x.BaseNewsInfo + " " + x.NewsInfoAll).ToList();
                }else if(ctr == "Clients")
                {
                    Client client = JsonConvert.DeserializeObject<Client>(responseBody);
                    new UpdateWindow(client).Show();
                }
               
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show("Не удается подключится к серверу");
            }

        }
       
       
    }
}
