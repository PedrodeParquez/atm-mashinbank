using System.Windows.Controls;

namespace atm_mashinbank.Views {
  public partial class PinCodeScreen : Page {
    public PinCodeScreen() {
      InitializeComponent();
    }

    public void TextBox_PIN_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) {
      if (!char.IsDigit(e.Text, 0)) {
        e.Handled = true;
      }
    }
  }
}
