using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrainzInfo_client.Connection;
using TrainzInfo_client.HttpPost;

namespace TrainzInfo_client.WIndows
{
    /// <summary>
    /// Логика взаимодействия для CityAddWindow.xaml
    /// </summary>
    public partial class CityAddWindow : Window
    {
        private Window stationAddWindow;
        public CityAddWindow(Window stationAddWindow)
        {
            this.stationAddWindow = stationAddWindow;
            InitializeComponent();
            Trace.WriteLine(this);
        }
        public void CityUpdate()
        {
            if(stationAddWindow is StationAddWindow)
            {
                (stationAddWindow as StationAddWindow).Update();
            }else if(stationAddWindow is OblastAddWindow)
            {
                (stationAddWindow as OblastAddWindow).Loading();
            }
        }
        private void CitySave_Click(object sender, RoutedEventArgs e)
        {
            Save();
            this.Close();
        }

        private void Save()
        {

            City city = new City
            {
                Name = City.Text
            };
            Post.Send("Cities", "CreateAction", this, city);
        }

        private void City_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Save();
                this.Close();
            }
        }
    }
}
