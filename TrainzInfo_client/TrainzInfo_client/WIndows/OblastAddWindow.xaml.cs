using Newtonsoft.Json;
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
    /// Логика взаимодействия для OblastAddWindow.xaml
    /// </summary>
    public partial class OblastAddWindow : Window
    {
        private Window window;
        public OblastAddWindow(Window window)
        {
            this.window = window;
            InitializeComponent();
            Trace.WriteLine(this);
            Loading();
        }

        public void Loading()
        {
            Post.Send("Cities", "IndexAction", this);
        }
        public void Update()
        {
            if(this.window is StationAddWindow)
            {
                (window as StationAddWindow).Update();
            }
        }

        private void OblastSave_Click(object sender, RoutedEventArgs e)
        {
            Oblast oblast = new Oblast
            {
                Name = OblastName.Text, OblCenter = OblCenterName.SelectedItem.ToString()
            };
            Post.Send("Oblasts", "CreateAction", this, JsonConvert.SerializeObject(oblast));
            this.Close();
        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {
            new CityAddWindow(this).Show();
        }
    }
}
