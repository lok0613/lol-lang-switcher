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

namespace LolLangSwitcher
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        protected LolClient lolClient;

        public MainWindow()
        {
            InitializeComponent();
            this.lolClient = new LolClient();

            if (!lolClient.IsLolClientExist())
            {
                UpdateStatusBar("Not Found. (Double click me)");
            } else
            {
                UpdateStatusBar(lolClient.ClientLocation);
            }
        }

        protected void SettleLolClient()
        {
            string path;
            System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = file.FileName;
                this.lolClient.ClientLocation = path;
                this.UpdateStatusBar(path);
            }
        }

        protected void UpdateStatusBar(string message)
        {
            ((Label)((System.Windows.Controls.Primitives.StatusBar)this.FindName("status_bar")).Items[0]).Content = "LOL Location: " + message;
        }
  
        private void FindLolClient(object sender, RoutedEventArgs e)
        {
            this.SettleLolClient();
        }

        protected void EnableLanguageForm(bool IsEnable = true)
        {
            ((StackPanel)this.FindName("language_form")).IsEnabled = IsEnable;
        }

        private void ChineseLobby_Click(object sender, RoutedEventArgs e)
        {
            EnableLanguageForm(false);
            new ChineseLobby(this.lolClient);
            EnableLanguageForm(true);
        }

        private void EnglishLobby_Click(object sender, RoutedEventArgs e)
        {
            EnableLanguageForm(false);
            new EnglishLobby(this.lolClient);
            EnableLanguageForm(true);
        }

        private void EnglishGame_Click(object sender, RoutedEventArgs e)
        {
            EnableLanguageForm(false);
            new EnglishGame(this.lolClient);
            EnableLanguageForm(true);
        }

        private void ChineseGame_Click(object sender, RoutedEventArgs e)
        {
            EnableLanguageForm(false);
            new ChineseGame(this.lolClient);
            EnableLanguageForm(true);
        }
    }
}
