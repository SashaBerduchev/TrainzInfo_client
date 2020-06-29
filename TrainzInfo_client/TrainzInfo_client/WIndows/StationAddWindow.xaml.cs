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

        private void Loading()
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
                City = City.SelectedItem.ToString(),
                Oblast = Oblast.SelectedItem.ToString(),
                Railway = Railway.SelectedItem.ToString(),
                Imgsrc = img.Text
            };
            Post.Send("Stations", "CreateAction", this, stations);
            this.Close();
        }
    }
}
