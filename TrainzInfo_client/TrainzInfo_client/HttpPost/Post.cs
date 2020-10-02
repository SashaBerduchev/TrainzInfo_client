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
using System.Xml;
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

        public async static void GetTrains()
        {
            List<Electic_locomotive> electic_locomotives = new List<Electic_locomotive>();
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("D://DB/Trains.xml");
                XmlElement xRoot = xmlDocument.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        Trace.WriteLine(xnode);
                    }

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        string nameseria = "";
                        string number = "";
                        int section;
                        int speed;
                        int power;
                        string img = "";
                        // если узел - company
                        if (childnode.Name == "train")
                        {
                            XmlNode attrname = childnode.Attributes.GetNamedItem("seria");
                            nameseria = attrname.Value;
                            XmlNode attrnum = childnode.Attributes.GetNamedItem("number");
                            number = attrnum.Value;
                            XmlNode attrsectuion = childnode.Attributes.GetNamedItem("sections");
                            section = Convert.ToInt32(attrsectuion.Value);
                            XmlNode attrspeed = childnode.Attributes.GetNamedItem("speed");
                            speed = Convert.ToInt32(attrspeed.Value);
                            XmlNode attrpower = childnode.Attributes.GetNamedItem("Power");
                            power = Convert.ToInt32(attrpower.Value);
                            Electic_locomotive electic_Locomotive = new Electic_locomotive
                            {
                                Seria = nameseria,
                                Number = number,
                                SectionCount = section,
                                Speed = speed,
                                ALlPowerP = power,
                                LocomotiveImg = ""
                            };

                            electic_locomotives.Add(electic_Locomotive);
                        }

                    }
                }
                Send("Electic_locomotive", "CreateAction", null, electic_locomotives);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public static async void GetSeriese()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("D://DB/Города.xml");
                XmlElement xRoot = xmlDocument.DocumentElement;
                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        Trace.WriteLine(xnode);
                    }

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        string nameseria = "";
                        // если узел - company
                        if (childnode.Name == "serie")
                        {
                            XmlNode attr = childnode.Attributes.GetNamedItem("name");
                            nameseria = attr.Value;

                            Locomotive_series locomotive_Series = new Locomotive_series
                            {
                                Seria = nameseria
                            };

                            Send("Locomotive_series", "DownloadAction", null, locomotive_Series);

                        }

                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString());
            }
        }

        public static async void GetCities()
        {
            
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("D://DB/Города.xml");
                XmlElement xRoot = xmlDocument.DocumentElement;
                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        string city ="";
                        string obl = "";
                        XmlNode attr1 = xnode.Attributes.GetNamedItem("name");
                        if (attr1 != null)
                        {
                            Trace.WriteLine(attr1);
                            city = attr1.Value;
                        }
                        XmlNode attr2 = xnode.Attributes.GetNamedItem("oblcenter");
                        if (attr2 != null)
                        {
                            Trace.WriteLine(attr2);
                            obl = attr2.Value;
                        }
                        Oblast oblast = new Oblast
                        {
                            Name = city,
                            OblCenter = obl
                        };
                        Send("Cities", "DownloadActionOblast", null, oblast);
                    }
                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        string cityname = "";
                        // если узел - company
                        if (childnode.Name == "city")
                        {
                            XmlNode attr = childnode.Attributes.GetNamedItem("name");
                            cityname = attr.Value;
                            City city = new City
                            {
                                Name = cityname
                            };
                            Send("Cities", "DownloadActionCity", null, city);

                        }
                    }
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString());
            }
        }

        public static async void SetDepot()
        {

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("D://DB/Города.xml");
                XmlElement xRoot = xmlDocument.DocumentElement;
                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        Trace.WriteLine(xnode);
                    }

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        string namedepo = "";
                        string filia = "";
                        string addres = "";
                        // если узел - company
                        if (childnode.Name == "depo")
                        {
                            XmlNode attr = childnode.Attributes.GetNamedItem("name");
                            namedepo = attr.Value;
                            XmlNode attr2 = childnode.Attributes.GetNamedItem("city");
                            addres = attr2.Value;
                            XmlNode attr3 = childnode.Attributes.GetNamedItem("filia");
                            filia = attr3.Value;
                            DepotList depot = new DepotList
                            {
                                Name = namedepo, 
                                Addres = addres,
                                UkrainsRailways = filia
                            };
                            Send("DepotLists", "DownloadActionDepot", null, depot);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
                MessageBox.Show(e.ToString());
            }
        }
        public static async void Send(string ctr, string act, Window window = null, object data = null)
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
                    if (window == null) return;
                    if (window is CityAddWindow)
                    {
                        (window as CityAddWindow).CityUpdate();
                    }
                    if (window is OblastAddWindow)
                    {
                        (window as OblastAddWindow).Update();
                    }
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
            if (win is MainWindow)
            {
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
                    (win as MainWindow).listinfo.ItemsSource = Electic_locomotive.Select(x => x.Seria + " " + x.SectionCount + " " + x.Speed + " " + x.ALlPowerP).ToList();
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
                else if (ctr == "StationsShadules")
                {
                    List<StationsShadule> stations = JsonConvert.DeserializeObject<List<StationsShadule>>(responseBody);
                    (win as MainWindow).listinfo.ItemsSource = stations.Select(x => x.Station + " " + x.TimeOfArrive + " " + x.TimeOfDepet + " " + x.UzFilia + " " + x.TrainInfo).ToList();
                }
            }
            else if (win is StationAddWindow)
            {
                if (ctr == "Oblasts")
                {
                    List<Oblast> oblasts = JsonConvert.DeserializeObject<List<Oblast>>(responseBody);
                    (win as StationAddWindow).Oblasttxt.ItemsSource = oblasts.Select(x => x.Name).ToList();
                }
                else if (ctr == "Cities")
                {
                    List<City> cities = JsonConvert.DeserializeObject<List<City>>(responseBody);
                    (win as StationAddWindow).Citytxt.ItemsSource = cities.Select(x => x.Name).ToList();
                }
                else if (ctr == "UkrainsRailways")
                {
                    List<UkrainsRailways> uz = JsonConvert.DeserializeObject<List<UkrainsRailways>>(responseBody);
                    (win as StationAddWindow).Railwaytxt.ItemsSource = uz.Select(x => x.Name).ToList();
                }
            }
            else if (win is OblastAddWindow)
            {
                List<Oblast> oblasts = JsonConvert.DeserializeObject<List<Oblast>>(responseBody);
                (win as OblastAddWindow).OblCenterName.ItemsSource = oblasts.Select(x => x.Name).ToList();
            }
            else if (win is StationsShaduleWindow)
            {
                if (ctr == "UkrainsRailways")
                {
                    List<UkrainsRailways> uz = JsonConvert.DeserializeObject<List<UkrainsRailways>>(responseBody);
                    (win as StationsShaduleWindow).UzFiliaCombo.ItemsSource = uz.Select(x => x.Name).ToList();
                }
                else if (ctr == "Stations")
                {
                    List<Stations> stations = JsonConvert.DeserializeObject<List<Stations>>(responseBody);
                    (win as StationsShaduleWindow).StationCombo.ItemsSource = stations.Select(x => x.Name).ToList();
                }
                else if (ctr == "Trains")
                {
                    List<Train> stations = JsonConvert.DeserializeObject<List<Train>>(responseBody);
                    (win as StationsShaduleWindow).TrainCombo.ItemsSource = stations.Select(x => x.NameOfTrain + " " + x.StationFrom + " "+ x.StationTo).ToList();
                }
            }
        }
    }
}
