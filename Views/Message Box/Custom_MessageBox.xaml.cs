using System.Windows;

namespace atm_mashinbank.Views.Message_Box {
  public partial class Custom_MessageBox : Window {
    public Custom_MessageBox() {
      InitializeComponent();
    }

    private void OK_Button_Click(object sender, RoutedEventArgs e) {
      DialogResult = true;
    }

    public static void Show(string title, string firstString, string secondString) {
      Custom_MessageBox messageBox = new Custom_MessageBox();

      messageBox.DefineMessageBox(title, firstString, secondString);

      if (messageBox.ShowDialog() == true) {
        return;
      }
    }

    public void DefineMessageBox(string title, string firstString, string secondString) {
      Title_TextBlock.Text = title;
      FirstString_TextBlock.Text = firstString;
      SecondString_TextBlock.Text = secondString;
    }
  }
}
