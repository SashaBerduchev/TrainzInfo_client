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
    /// Логика взаимодействия для StationAddWindow.xaml
    /// </summary>
    public partial class StationAddWindow : Window
    {
        public StationAddWindow()
        {
            InitializeComponent();
            Trace.WriteLine(this);
            Loading();
        }

        public void Update()
        {
            Loading();
        }
        protected async Task Loading()
        {
            Post.Send("Oblasts", "IndexAction", this);
            Post.Send("Cities", "IndexAction", this);
            Post.Send("UkrainsRailways", "IndexAction", this);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Stations stations = new Stations
            {
                Name = Nametxt.Text,
                City = Citytxt.SelectedItem.ToString(),
                Oblast = Oblasttxt.SelectedItem.ToString(),
                Railway = Railwaytxt.SelectedItem.ToString(),
                Imgsrc = img.Text
            };
            Post.Send("Stations", "CreateAction", this, stations);
            this.Close();
        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {
            new CityAddWindow(this).Show();
        }

        private void AddOblast_Click(object sender, RoutedEventArgs e)
        {
            new OblastAddWindow(this).Show();
        }

        private void Citytxt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Nametxt.Text = Citytxt.SelectedItem.ToString();
        }
    }
}
