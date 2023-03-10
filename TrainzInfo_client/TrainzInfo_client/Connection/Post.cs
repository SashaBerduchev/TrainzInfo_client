using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using TrainzInfo_client.HttpPost;
using TrainzInfo_client.WIndows;

namespace TrainzInfo_client.Connection
{
    internal class Post
    {
        private static string constring;
        static readonly HttpClient client = new HttpClient();
        public Post()
        {
            constring = Config.GetString();

        }
        public static async Task<string> Send(string ctr, string act, Window window = null, string data = null)
        {
            try
            {
                string constr = constring + ctr + '/' + act;
                Trace.WriteLine("POST " + constr);
                string filedata = "PostLog.log";
                FileStream fileStream = new FileStream(filedata, FileMode.Append);
                byte[] array = Encoding.Default.GetBytes(constr + "             ");
                fileStream.Write(array, 0, constr.Length);
                fileStream.Close();
                if (data != null)
                {
                    var poststr = data.Trim('/');
                    StringContent stringContent = new StringContent(poststr);
                    HttpResponseMessage request = await client.PostAsync(constr, new StringContent(new JavaScriptSerializer().Serialize(data), Encoding.UTF8, "application/json"));
                    var ddd = await request.Content.ReadAsStringAsync();
                    Trace.WriteLine(request);
                    Trace.WriteLine(ddd);
                    return ddd;
                }
                else
                {
                    HttpResponseMessage response = await client.GetAsync(constr);
                    response.EnsureSuccessStatusCode();
                    Trace.WriteLine("POST  " + response);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                return "";

            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show("Не удается подключится к серверу");
                return "Не удается подключится к серверу";
            }

        }

        //private static void ParsData(string ctr, Window win, string responseBody)
        //{
        //    if (win is MainWindow)
        //    {
        //        if (ctr == "NewsInfoes")
        //        {
        //            List<NewsInfoes> news = JsonConvert.DeserializeObject<List<NewsInfoes>>(responseBody);
        //            Trace.WriteLine(news.Select(x => x.id + " " + x.NameNews + " " + x.BaseNewsInfo + " " + x.NewsInfoAll));
        //            (win as MainWindow).listinfo.ItemsSource = news.Select(x => x.id + " " + x.NameNews + " " + x.BaseNewsInfo + " " + x.NewsInfoAll).ToList();
        //        }
        //        else if (ctr == "Clients")
        //        {
        //            Client client = JsonConvert.DeserializeObject<Client>(responseBody);
        //            if (client.IsUpdate == true)
        //            {
        //                new UpdateWindow(client).Show();
        //            }
        //        }
        //        else if (ctr == "Electic_locomotive")
        //        {
        //            List<Electic_locomotive> Electic_locomotive = JsonConvert.DeserializeObject<List<Electic_locomotive>>(responseBody);
        //            (win as MainWindow).listinfo.ItemsSource = Electic_locomotive.Select(x => x.Seria + " " + x.SectionCount + " " + x.Speed + " " + x.ALlPowerP).ToList();
        //        }
        //        else if (ctr == "DieselLocomoives")
        //        {
        //            List<DieselLocomitives> dieselLocomitives = JsonConvert.DeserializeObject<List<DieselLocomitives>>(responseBody);
        //            (win as MainWindow).listinfo.ItemsSource = dieselLocomitives.Select(x => x.Name + " " + x.SectionCount + " " + x.MaxSpeed + " " + x.DiseslPower).ToList();
        //        }
        //        else if (ctr == "ElectricTrain")
        //        {
        //            List<ElectricTrain> ElectricTrain = JsonConvert.DeserializeObject<List<ElectricTrain>>(responseBody);
        //            (win as MainWindow).listinfo.ItemsSource = ElectricTrain.Select(x => x.Name + " " + "" + x.VagonsCountP + " " + x.MaxSpeed).ToList();
        //        }
        //        else if (ctr == "UkrainsRailways")
        //        {
        //            List<UkrainsRailways> Electic_locomotive = JsonConvert.DeserializeObject<List<UkrainsRailways>>(responseBody);
        //            (win as MainWindow).listinfo.ItemsSource = Electic_locomotive.Select(x => x.Name + " " + x.Information).ToList();
        //        }
        //        else if (ctr == "Stations")
        //        {
        //            List<Stations> stations = JsonConvert.DeserializeObject<List<Stations>>(responseBody);
        //            (win as MainWindow).listinfo.ItemsSource = stations.Select(x => x.Name + " " + x.Oblast + " " + x.Railway + " " + x.City).ToList();
        //        }
        //        else if (ctr == "StationsShadules")
        //        {
        //            List<StationsShadule> stations = JsonConvert.DeserializeObject<List<StationsShadule>>(responseBody);
        //            (win as MainWindow).listinfo.ItemsSource = stations.Select(x => x.Station + " " + x.TimeOfArrive + " " + x.TimeOfDepet + " " + x.UzFilia + " " + x.TrainInfo).ToList();
        //        }
        //    }
        //    else if (win is StationAddWindow)
        //    {
        //        if (ctr == "Oblasts")
        //        {
        //            List<Oblast> oblasts = JsonConvert.DeserializeObject<List<Oblast>>(responseBody);
        //            (win as StationAddWindow).Oblasttxt.ItemsSource = oblasts.Select(x => x.Name).ToList();
        //        }
        //        else if (ctr == "Cities")
        //        {
        //            List<City> cities = JsonConvert.DeserializeObject<List<City>>(responseBody);
        //            (win as StationAddWindow).Citytxt.ItemsSource = cities.Select(x => x.Name).ToList();
        //        }
        //        else if (ctr == "UkrainsRailways")
        //        {
        //            List<UkrainsRailways> uz = JsonConvert.DeserializeObject<List<UkrainsRailways>>(responseBody);
        //            (win as StationAddWindow).Railwaytxt.ItemsSource = uz.Select(x => x.Name).ToList();
        //        }
        //    }
        //    else if (win is OblastAddWindow)
        //    {
        //        List<Oblast> oblasts = JsonConvert.DeserializeObject<List<Oblast>>(responseBody);
        //        (win as OblastAddWindow).OblCenterName.ItemsSource = oblasts.Select(x => x.Name).ToList();
        //    }
        //    else if (win is StationsShaduleWindow)
        //    {
        //        if (ctr == "UkrainsRailways")
        //        {
        //            List<UkrainsRailways> uz = JsonConvert.DeserializeObject<List<UkrainsRailways>>(responseBody);
        //            (win as StationsShaduleWindow).UzFiliaCombo.ItemsSource = uz.Select(x => x.Name).ToList();
        //        }
        //        else if (ctr == "Stations")
        //        {
        //            List<Stations> stations = JsonConvert.DeserializeObject<List<Stations>>(responseBody);
        //            (win as StationsShaduleWindow).StationCombo.ItemsSource = stations.Select(x => x.Name).ToList();
        //        }
        //        else if (ctr == "Trains")
        //        {
        //            List<Train> stations = JsonConvert.DeserializeObject<List<Train>>(responseBody);
        //            (win as StationsShaduleWindow).TrainCombo.ItemsSource = stations.Select(x => x.NameOfTrain + " " + x.StationFrom + " " + x.StationTo).ToList();
        //        }
        //    }
        //}
    }
}

