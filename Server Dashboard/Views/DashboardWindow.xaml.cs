﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Server_Dashboard.Views {
    /// <summary>
    /// Interaktionslogik für DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window {
        public DashboardWindow() {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e) {
            foreach(Button b in TopBarGrid.Children) {
                //b.Template.FindName("TopBarButtonImage")
            }
        }
    }
}
