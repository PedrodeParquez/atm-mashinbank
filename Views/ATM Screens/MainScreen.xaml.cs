using System.Windows;
using System.Windows.Controls;

namespace atm_mashinbank.Views {
  public partial class MainScreen : Page {
    public MainScreen() {
      InitializeComponent();
    }

    MainWindow window = Application.Current.MainWindow as MainWindow;

    private async void Withdrawl_Button_Click(object sender, RoutedEventArgs e) {
      await window.ChangeScreen(1000, new LoadingScreen());
      await window.ChangeScreen(2000, new WithdrawalScreen());
    }

    private async void Deposit_Button_Click(object sender, RoutedEventArgs e) {
      await window.ChangeScreen(1000, new LoadingScreen());
      await window.ChangeScreen(2000, new DepositScreen());
    }

    private async void Personal_Page_Button_Click(object sender, RoutedEventArgs e) {
      await window.ChangeScreen(1000, new LoadingScreen());
      await window.ChangeScreen(2000, new PersonalPageScreen());
    }

    private async void Exit_Button_Click(object sender, RoutedEventArgs e) {
      await window.ChangeScreen(1000, new LoadingScreen());
      await window.ChangeScreen(2000, new HomeScreen());
    }
  }
}
