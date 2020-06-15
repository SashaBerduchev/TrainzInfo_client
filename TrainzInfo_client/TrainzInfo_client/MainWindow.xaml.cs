﻿using Newtonsoft.Json;
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
            StartClient();
            Trace.WriteLine(this);
            GetUpdate();
            Main();
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
            Post.Send("NewsInfoes", "IndexAction", this);

        }

        private void btnNewsAdd_Click(object sender, RoutedEventArgs e)
        {
            new NewsWindow().Show();
        }

        private void btnElectric_locomotives_Click(object sender, RoutedEventArgs e)
        {
            Post.Send("Electic_locomotive", "IndexAction", this);
        }
    }
}
