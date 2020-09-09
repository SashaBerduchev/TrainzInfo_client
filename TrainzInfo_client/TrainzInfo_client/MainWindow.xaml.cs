using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrainzInfo_client.HttpPost;
using TrainzInfo_client.WIndows;

namespace TrainzInfo_client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ModeType.Items.Add("DEBUG");
            ModeType.Items.Add("RELEASE");
            StartClient();
            Trace.WriteLine(this);
            GetUpdate();
            Main();;
             
        }

        private void GetCities()
        {
            Post.GetCities();
        }

        private void GetUpdate()
        {
            Post.Send("Clients", "GetUpdate", this);
        }

        private void StartClient()
        {
            Post post = new Post();
        }

        public async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.

            Post.Send("NewsInfoes", "IndexAction", this);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Main();

        }

        private void btnNewsAdd_Click(object sender, RoutedEventArgs e)
        {
            new NewsWindow().Show();
        }

        private void btnElectric_locomotives_Click(object sender, RoutedEventArgs e)
        {
            Post.Send("Electic_locomotive", "IndexAction", this);
        }

        private void ElectrickLocomotiveAdd_Click(object sender, RoutedEventArgs e)
        {
            new ElectrickLocomotiveWindow().Show();
        }

        private void btnDiesel_locomotives_Copy_Click(object sender, RoutedEventArgs e)
        {
            Post.Send("DieselLocomoives", "IndexAction", this);
        }

        private void electrickList_Click(object sender, RoutedEventArgs e)
        {
            Post.Send("ElectricTrains", "IndexAction", this);
        }

        private void AddElectric_Click(object sender, RoutedEventArgs e)
        {
            new ElectrickTrainWindow().Show();
        }

        private void UkrainRailways_Click(object sender, RoutedEventArgs e)
        {
            Post.Send("UkrainsRailways", "IndexAction", this);
        }

        private void AddUZFiliy_Click(object sender, RoutedEventArgs e)
        {
            new UkrzaliznutsaFilies().Show();
        }

        private void StationsList_Click(object sender, RoutedEventArgs e)
        {
            Post.Send("Stations", "IndexAction", this);
        }

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            new StationAddWindow().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Post.Send("StationsShadules", "IndexAction", this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new StationsShaduleWindow().Show();
        }

        private void ModeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string type = ModeType.SelectedItem.ToString();
            if (type == "RELEASE")
            {
                Config.DEBUG_MODE = false;
            }
            else
            {
                Config.DEBUG_MODE = true;
            }
            StartClient();
            Main();
        }

        private void LoodCiti_Click(object sender, RoutedEventArgs e)
        {
            GetCities();
        }
    }
}
