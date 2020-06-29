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
                Trace.WriteLine("POST " + constr);
                if (data != null)
                {
                    var senddata = JsonConvert.SerializeObject(data);
                    Trace.WriteLine("POST " + senddata);
                    HttpResponseMessage request = await client.PostAsJsonAsync(constr, senddata);
                    Trace.WriteLine(request);
                }
                else
                {
                    HttpResponseMessage response = await client.GetAsync(constr);
                    response.EnsureSuccessStatusCode();
                    Trace.WriteLine("POST  " + response);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Trace.WriteLine("RESPONSE" + responseBody.ToString());
                    ParsData(ctr, window, responseBody);
                }
               
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show("Не удается подключится к серверу");
            }

        }

        private static void ParsData(string ctr, Window win, string responseBody)
        {
            if(win is MainWindow) {
                if (ctr == "NewsInfoes")
                {
                    List<NewsInfoes> news = JsonConvert.DeserializeObject<List<NewsInfoes>>(responseBody);
                    Trace.WriteLine(news.Select(x => x.id + " " + x.NameNews + " " + x.BaseNewsInfo + " " + x.NewsInfoAll));
                    (win as MainWindow).listinfo.ItemsSource = news.Select(x => x.id + " " + x.NameNews + " " + x.BaseNewsInfo + " " + x.NewsInfoAll).ToList();
                }
                else if (ctr == "Clients")
                {
                    Client client = JsonConvert.DeserializeObject<Client>(responseBody);
                    if (client.IsUpdate == true)
                    {
                        new UpdateWindow(client).Show();
                    }
                }
                else if (ctr == "Electic_locomotive")
                {
                    List<Electic_locomotive> Electic_locomotive = JsonConvert.DeserializeObject<List<Electic_locomotive>>(responseBody);
                    (win as MainWindow).listinfo.ItemsSource = Electic_locomotive.Select(x => x.Name + " " + x.SectionCount + " " + x.Speed + " " + x.ALlPowerP).ToList();
                }
                else if (ctr == "DieselLocomoives")
                {
                    List<DieselLocomitives> dieselLocomitives = JsonConvert.DeserializeObject<List<DieselLocomitives>>(responseBody);
                    (win as MainWindow).listinfo.ItemsSource = dieselLocomitives.Select(x => x.Name + " " + x.SectionCount + " " + x.MaxSpeed + " " + x.DiseslPower).ToList();
                }
                else if (ctr == "ElectricTrain")
                {
                    List<ElectricTrain> ElectricTrain = JsonConvert.DeserializeObject<List<ElectricTrain>>(responseBody);
                    (win as MainWindow).listinfo.ItemsSource = ElectricTrain.Select(x => x.Name + " " + "" + x.VagonsCountP + " " + x.MaxSpeed).ToList();
                }
                else if (ctr == "UkrainsRailways")
                {
                    List<UkrainsRailways> Electic_locomotive = JsonConvert.DeserializeObject<List<UkrainsRailways>>(responseBody);
                    (win as MainWindow).listinfo.ItemsSource = Electic_locomotive.Select(x => x.Name + " " + x.Information).ToList();
                }
                else if (ctr == "Stations")
                {
                    List<Stations> stations = JsonConvert.DeserializeObject<List<Stations>>(responseBody);
                    (win as MainWindow).listinfo.ItemsSource = stations.Select(x => x.Name + " " + x.Oblast + " " + x.Railway + " " + x.City).ToList();
                }
            }else if(win is StationAddWindow){
                if(ctr == "Oblasts")
                {
                    List<Oblast> oblasts = JsonConvert.DeserializeObject<List<Oblast>>(responseBody);
                    (win as StationAddWindow).Oblast.ItemsSource = oblasts.Select(x => x.Name).ToList();
                }else if(ctr == "Cities")
                {
                    List<City> cities = JsonConvert.DeserializeObject<List<City>>(responseBody);
                    (win as StationAddWindow).City.ItemsSource = cities.Select(x => x.Name).ToList();
                }else if(ctr == "UkrainsRailways")
                {
                    List<UkrainsRailways> uz = JsonConvert.DeserializeObject<List<UkrainsRailways>>(responseBody);
                    (win as StationAddWindow).Railway.ItemsSource = uz.Select(x => x.Name).ToList();
                }
            }
        }
    }
}
