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
    /// Логика взаимодействия для ElectrickTrainWindow.xaml
    /// </summary>
    public partial class ElectrickTrainWindow : Window
    {
        public ElectrickTrainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ElectricTrain electricTrain = new ElectricTrain
                {
                    Name = namebox.Text,
                    MaxSpeed = Convert.ToInt32(maxspeed.Text),
                    VagonsCountP = vagonbox.Text,
                    Imgsrc = imgstr.Text
                };
                Post.Send("ElectricTrains", "CreateAction", this, electricTrain);
            }catch(Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                MessageBox.Show(exp.ToString(), "Error");
            }
        }
    }
}
