using atm_mashinbank.Views.Message_Box;
using System.Windows;
using System.Windows.Controls;

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

        Custom_MessageBox.Show("Успешно", "Баланс: ", "Наличные: ");
        return;
      }

      Custom_MessageBox.Show("Предупреждение", "Недостаточно средств для внесения!", "Повторите попытку!");
    }
  }
}
