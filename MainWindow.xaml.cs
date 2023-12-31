﻿using atm_mashinbank.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace atm_mashinbank {
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      Screen.Content = new SuccessfulWithdrawalScreen();
    }

    private void FirstBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
      if (e.ChangedButton == MouseButton.Left) {
        DragMove();
      }
    }

    private void SecondBar_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e) {
      if (e.ChangedButton == MouseButton.Left) {
        DragMove();
      }
    }
  }
}
