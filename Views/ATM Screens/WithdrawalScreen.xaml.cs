using System.Windows;
using System.Windows.Controls;

namespace atm_mashinbank.Views {
  public partial class WithdrawalScreen : Page {
    public WithdrawalScreen() {
      InitializeComponent();
    }

    MainWindow window = Application.Current.MainWindow as MainWindow;

    private async void Home_Button_Click(object sender, RoutedEventArgs e) {
      await window.ChangeScreen(1000, new LoadingScreen());
      await window.ChangeScreen(2000, new MainScreen());
    }

    private async void Withdrawal_Button_Click(object sender, RoutedEventArgs e) {
      string withdrawalText = TextBox_Withdrawal.Text.Trim(' ', '₽');

      if (double.TryParse(withdrawalText, out double withdrawalAmount) && withdrawalAmount <= 1000) { 
        await window.ChangeScreen(1000, new WaitingWithdrawalScreen());
        await window.ChangeScreen(2000, new SuccessfulWithdrawalScreen());
        return;
      }

      MessageBox.Show("Недостаточно средств для снятия наличных!\nПовторите попытку!");
    }
  }
}
