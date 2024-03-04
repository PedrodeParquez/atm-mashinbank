﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace atm_mashinbank.Views {
  public partial class DepositScreen : Page {
    public DepositScreen() {
      InitializeComponent();
    }

    MainWindow window = Application.Current.MainWindow as MainWindow;

    private async void Home_Button_Click(object sender, RoutedEventArgs e) {
      await window.ChangeScreen(1000, new LoadingScreen());
      await window.ChangeScreen(2000, new MainScreen());
    }

    private async void Deposit_Button_Click(object sender, RoutedEventArgs e) {
      string depositText = TextBox_Deposit.Text.Trim(' ', '₽');

      if (double.TryParse(depositText, out double depositAmount) && depositAmount <= 1000) {
        await window.ChangeScreen(1000, new WaitingDepositScreen());
        await window.ChangeScreen(2000, new SuccsessfulDepositScreen());
        return;
      }

      MessageBox.Show("Недостаточно средств для внесения!\nПовторите попытку!");
    }
  }
}
