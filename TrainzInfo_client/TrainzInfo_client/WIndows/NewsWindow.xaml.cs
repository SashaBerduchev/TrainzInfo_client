using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private string fileType = "image/jpeg";
        private byte[] fileName;
        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            string fileContent;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            var fileStream = fileDialog.OpenFile();

            //using (StreamReader reader = new StreamReader(fileStream))
            //{
            //    fileContent = reader.ReadToEnd();
            //    byte[] arr = Encoding.Unicode.GetBytes(fileContent);
            //    MemoryStream ms = new MemoryStream(arr);
            //    fileName = ms.ToArray();
            //}

            //fileType = Path.GetExtension(fileDialog.FileName);
            string filedata = fileDialog.FileName;
            Img.Source = new BitmapImage(new Uri(filedata));
            byte[] bData = File.ReadAllBytes(fileDialog.FileName);
            fileName = bData;
            Trace.WriteLine(fileDialog);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewsInfoes newsInfoes = new NewsInfoes {
                NameNews = NameNews.Text, BaseNewsInfo = BaseNews.Text, NewsInfoAll = AllNewsInfo.Text, NewsImage = fileName, ImageMimeTypeOfData = fileType
            };
            Post.Send("NewsInfoes", "CreateAction", this, JsonConvert.SerializeObject(newsInfoes));
            this.Close();
        }
    }
}
