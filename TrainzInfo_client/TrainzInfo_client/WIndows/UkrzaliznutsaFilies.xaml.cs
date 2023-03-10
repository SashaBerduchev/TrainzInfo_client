using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UkrzaliznutsaFilies.xaml
    /// </summary>
    public partial class UkrzaliznutsaFilies : Window
    {
        public UkrzaliznutsaFilies()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UkrainsRailways ukrainsRailways = new UkrainsRailways
            {
                Name = Name.Text,
                Information = Info.Text,
                Photo = Img.Text
            };
            Post.Send("UkrainsRailways", "CreateAction", this, JsonConvert.SerializeObject(ukrainsRailways));
            this.Close();
        }
    }
}
