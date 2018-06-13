using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
        // This is really bad/weak method to encrypt files
        String WeakEncryptMethod(String textIn)
        {
            Char[] temp = textIn.ToArray<Char>();

            for (int i = 0; i < textIn.Length; i++)
            {
                temp[i] = (char)((int)temp[i] + 3);
            }
            return new String(temp);
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // If file exist and login and password are "correct"
            if (File.Exists(@"C:\Users\Jakub Kacorzyk\Desktop\SOAProject\VoiceClient\WpfClient\Users.txt")
                && LoginR.Text.Length >= 3
                && PasswordR.Password.Length >= 3
                && PasswordCheckR.Password == PasswordR.Password)
            {
                StringBuilder stringBuilder = new StringBuilder();
                using (StreamReader streamReader = new StreamReader(@"C:\Users\Jakub Kacorzyk\Desktop\SOAProject\VoiceClient\WpfClient\Users.txt"))
                {
                    stringBuilder.Append(streamReader.ReadToEnd());
                }
                using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\Jakub Kacorzyk\Desktop\SOAProject\VoiceClient\WpfClient\Users.txt"))
                {
                    streamWriter.Write(stringBuilder.ToString());
                    streamWriter.WriteLine(WeakEncryptMethod(LoginR.Text));
                    streamWriter.WriteLine(WeakEncryptMethod(PasswordR.Password));
                }
                this.Close();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
