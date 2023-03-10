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
    /// Логика взаимодействия для ElectrickLocomotiveWindow.xaml
    /// </summary>
    public partial class ElectrickLocomotiveWindow : Window
    {
        public ElectrickLocomotiveWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Electic_locomotive electic_Locomotive = new Electic_locomotive
            {
                Seria = Name.Text,
                LocomotiveImg = LocomotiveImg.Text,
                SectionCount = Convert.ToInt32(SectionCountText.Text),
                ALlPowerP = Convert.ToInt32(ALlPowerText.Text)
            };
            Post.Send("Electic_locomotive", "CreateAction", this, electic_Locomotive);
            this.Close();

        }
    }
}
