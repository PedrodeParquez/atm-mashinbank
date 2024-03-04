using atm_mashinbank.Views;
using atm_mashinbank.Model;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace atm_mashinbank {
  public partial class MainWindow : Window {
    private CustomSoundPlayer backgroundMusicPlayer;

    bool CardIn = false;
    int attempts = 0;

    public MainWindow() {
      InitializeComponent();
      
      backgroundMusicPlayer = new CustomSoundPlayer("C:\\Users\\Егор\\source\\repos\\atm-mashinbank\\Resources\\Sounds\\Music\\Background_Music.wav");
      Screen.Content = new HomeScreen();
    }

    //Handlers

    public async Task ChangeScreen(int time, Page page) {
      await Task.Delay(time);
      Screen.Content = page;
    }

    public void CardHandler(string phrase, bool flag) {
      ButtonInsertPickUpCard.Content = phrase;
      CardIn = flag;
    }

    private void ButtonPanel(string symbol) {
      if (Screen.Content is PinCodeScreen TextBox_PIN) {
        TextBox_PIN.TextBox_PIN.Password += symbol;
        return;
      }

      if (Screen.Content is DepositScreen TextBox_Dep) {
        int caretIndex = TextBox_Dep.TextBox_Deposit.CaretIndex;
        TextBox_Dep.TextBox_Deposit.Text = TextBox_Dep.TextBox_Deposit.Text.Insert(caretIndex, symbol);
        TextBox_Dep.TextBox_Deposit.CaretIndex = caretIndex + 1;
        return;
      }

      if (Screen.Content is WithdrawalScreen TextBox_With) {
        int caretIndex = TextBox_With.TextBox_Withdrawal.CaretIndex;
        TextBox_With.TextBox_Withdrawal.Text = TextBox_With.TextBox_Withdrawal.Text.Insert(caretIndex, symbol);
        TextBox_With.TextBox_Withdrawal.CaretIndex = caretIndex + 1;
        return;
      }
    }

    //ToolBar

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

    //Numeric Keypad
    private void Button_1_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("1");
    }

    private void Button_2_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("2");
    }

    private void Button_3_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("3");
    }

    private void Button_4_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("4");
    }

    private void Button_5_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("5");
    }

    private void Button_6_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("6");
    }

    private void Button_7_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("7");
    }

    private void Button_8_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("8");
    }

    private void Button_9_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("9");
    }

    private void Button_Dot_Click(object sender, RoutedEventArgs e) {
      ButtonPanel(".");
    }

    private void Button_0_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("0");
    }

    private void Button_00_Click(object sender, RoutedEventArgs e) {
      ButtonPanel("00");
    }

    //Service buttons

    private async void Button_Cancel_Click(object sender, RoutedEventArgs e) {
      if (Screen.Content is PinCodeScreen || Screen.Content is MainScreen) {
        await ChangeScreen(1000, new LoadingScreen());
        await ChangeScreen(2000, new HomeScreen());

        CardHandler("Вставить карту", false);
        
        return;
      }

      if (Screen.Content is DepositScreen) {
        await ChangeScreen(1000, new LoadingScreen());
        await ChangeScreen(2000, new MainScreen());
        return;
      }

      if (Screen.Content is WithdrawalScreen) {
        await ChangeScreen(1000, new LoadingScreen());
        await ChangeScreen(2000, new MainScreen());
        return;
      }

    }

    private void Button_Clear_Click(object sender, RoutedEventArgs e) {
      if (Screen.Content is PinCodeScreen TextBox_PIN) {
        TextBox_PIN.TextBox_PIN.Clear();
        return;
      }

      if (Screen.Content is DepositScreen TextBox_Dep) {
        TextBox_Dep.TextBox_Deposit.Clear();
        TextBox_Dep.TextBox_Deposit.Text = " ₽";
        return;
      }

      if (Screen.Content is WithdrawalScreen TextBox_With) {
        TextBox_With.TextBox_Withdrawal.Clear();
        TextBox_With.TextBox_Withdrawal.Text = " ₽";
        return;
      }
    }

    private async void Button_Enter_Click(object sender, RoutedEventArgs e) {
      if (Screen.Content is PinCodeScreen TextBox_PIN) {
        if (TextBox_PIN.TextBox_PIN.Password == "1234") {
          await ChangeScreen(1000, new LoadingScreen());
          await ChangeScreen(2000, new MainScreen());
          return;
        }

        if (attempts == 2) {
          await ChangeScreen(1000, new LockedScreen());
          MessageBox.Show("Банкомат заблокирован!\nПерезапустите приложение!");
          attempts = 0;
          return;
        }

        attempts++;
        MessageBox.Show("Неправильный пароль!\nПовторите попытку!");
      }

      if (Screen.Content is DepositScreen TextBox_Dep) {
        string depositText = TextBox_Dep.TextBox_Deposit.Text.Trim(' ', '₽');

        if (double.TryParse(depositText, out double depositAmount) && depositAmount <= 1000) {
          await ChangeScreen(1000, new WaitingDepositScreen());
          await ChangeScreen(2000, new SuccsessfulDepositScreen());
          return;
        }

        MessageBox.Show("Недостаточно средств для внесения!\nПовторите попытку!");
      }

      if (Screen.Content is WithdrawalScreen TextBox_With) {
        string withdrawalText = TextBox_With.TextBox_Withdrawal.Text.Trim(' ', '₽');

        if (double.TryParse(withdrawalText, out double withdrawalAmount) && withdrawalAmount <= 1000) {
          await ChangeScreen(1000, new WaitingWithdrawalScreen());
          await ChangeScreen(2000, new SuccessfulWithdrawalScreen());
          return;
        }

        MessageBox.Show("Недостаточно средств для снятия наличных!\nПовторите попытку!");
      }
    }

    private void Button_Empty_Click(object sender, RoutedEventArgs e) {
      MessageBox.Show("Зачем меня создали?(", "Кнопка");
    }

    //Cash button

    private void Button_Input_Cash_Click(object sender, RoutedEventArgs e) {

    }

    //Card button

    private async void Button_Insert_Pick_Up_Card_Click(object sender, RoutedEventArgs e) {
      await ChangeScreen(2000, new LoadingScreen());

      if (!CardIn) {
        await ChangeScreen(2000, new PinCodeScreen());

        CardHandler("Забрать карту", true);

        return;
      }

      await ChangeScreen(2000, new HomeScreen());

      CardHandler("Вставить карту", false);
    }
  }
}
