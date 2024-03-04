using System.Windows;
using System.Windows.Controls;

namespace atm_mashinbank.Views {
  public partial class SuccessfulWithdrawalScreen : Page {
    public SuccessfulWithdrawalScreen() {
      InitializeComponent();
    }

    MainWindow window = Application.Current.MainWindow as MainWindow;

    private async void Home_Button_Click(object sender, RoutedEventArgs e) {
      await window.ChangeScreen(1000, new LoadingScreen());
      await window.ChangeScreen(2000, new MainScreen());
    }

    private async void Exit_Button_Click(object sender, RoutedEventArgs e) {
      await window.ChangeScreen(1000, new LoadingScreen());
      await window.ChangeScreen(2000, new HomeScreen());

      window.CardHandler("Вставить карту", false);
    }
  }
}
