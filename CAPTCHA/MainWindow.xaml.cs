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

namespace CAPTCHA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string captchaText;
        public MainWindow()
        {
            InitializeComponent();
            GenerateCaptcha();
            captchaTextBox.Focus();
        }
        private void GenerateCaptcha()
        {
            Random random = new Random();
            captchaText = "";

            for (int i = 0; i < 6; i++)
            {
                captchaText += (char)random.Next(65, 90);
            }

            captchaTextBlock.Text = captchaText;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (captchaTextBox.Text == captchaText)
            {
                MessageBox.Show("CAPTCHA passed!");
                GenerateCaptcha();
                captchaTextBox.Clear();
                captchaTextBox.Focus();
            }
            else
            {
                MessageBox.Show("CAPTCHA failed! Please try again.");
                GenerateCaptcha();
                captchaTextBox.Clear();
                captchaTextBox.Focus();
            }
        }
    }
}
