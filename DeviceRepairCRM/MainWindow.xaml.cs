﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeviceRepairCRM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new OrderFrame();
        }

        private void DeviceFrameBt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DeviceFrame();
        }

        private void OrderFrameBt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new OrderFrame();
        }
        public void DeviceAddBtClick()
        {
            MainFrame.Content = new DeviceAddFrame();
        }
    }
}
