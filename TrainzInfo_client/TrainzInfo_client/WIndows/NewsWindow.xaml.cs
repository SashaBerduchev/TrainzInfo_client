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
    /// Логика взаимодействия для NewsWindow.xaml
    /// </summary>
    public partial class NewsWindow : Window
    {
        public NewsWindow()
        {
            InitializeComponent();
            Trace.WriteLine(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewsInfoes newsInfoes = new NewsInfoes {
                NameNews = NameNews.Text, BaseNewsInfo = BaseNews.Text, NewsInfoAll = AllNewsInfo.Text, Imgsrc = PhotoUrl.Text
            };
            Post.Send("NewsInfoes", "CreateAction", this, newsInfoes);
            this.Close();
        }
    }
}
