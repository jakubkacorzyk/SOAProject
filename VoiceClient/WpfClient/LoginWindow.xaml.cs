using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!File.Exists(path + "\\Users.txt"))
            {
                File.Create(path + "\\Users.txt");
            }
        }
        
        String WeakDecryptMethod(String textIn)
        {
            Char[] temp = textIn.ToArray<Char>();
            for (int i = 0; i < textIn.Length; i++)
            {
                temp[i] = (char)((int)temp[i] - 3);
            }
            return new String(temp);
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Status.Visibility = Visibility.Hidden;
            RegisterWindow newWindow = new RegisterWindow();
            newWindow.ShowDialog();
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Status.Visibility = Visibility.Hidden;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // If file exist and login and password are "correct"
            if (File.Exists(path + "\\Users.txt")
                && Login.Text.Length >= 3
                && Password.Password.Length >= 3)
            {
                using (StreamReader streamReader = new StreamReader(path + "\\Users.txt"))
                {
                    // While there is something in streamReader read it
                    while (streamReader.Peek() >= 0)
                    {
                        String decryptedLogin = WeakDecryptMethod(streamReader.ReadLine());
                        String decryptedPass = WeakDecryptMethod(streamReader.ReadLine());
                        if (decryptedLogin == Login.Text && decryptedPass == Password.Password)
                        {
                            BotWindow botWindow = new BotWindow();
                            botWindow.Show();
                            this.Close();
                            break;
                        }

                    }

                    Status.Visibility = Visibility.Visible;
                    Status.Text = "Invalid username or password.";


                }
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}

