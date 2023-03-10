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
    /// Логика взаимодействия для StationsShaduleWindow.xaml
    /// </summary>
    public partial class StationsShaduleWindow : Window
    {
        public StationsShaduleWindow()
        {
            InitializeComponent();
            Trace.WriteLine(this);
            Loading();
        }

        private void Loading()
        {
            Post.Send("UkrainsRailways", "IndexAction", this);
            Post.Send("Stations", "IndexAction", this);
            Post.Send("Trains", "IndexAction", this);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StationsShadule stationsShadule = new StationsShadule
            {
                Station = StationCombo.SelectedItem.ToString(),
                TimeOfArrive = DateTime.Parse(TimeArrive.Text, System.Globalization.CultureInfo.InvariantCulture),
                TimeOfDepet = DateTime.Parse(TimeDepet.Text, System.Globalization.CultureInfo.InvariantCulture),
                TrainInfo = TrainCombo.SelectedItem.ToString(),
                ImgTrain = ImgSrc.Text,
                UzFilia = UzFiliaCombo.SelectedItem.ToString()
            };
            Post.Send("StationsShadules", "CreateAction", this, stationsShadule);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
