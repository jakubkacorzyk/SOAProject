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
using System.Windows.Shapes;
using WpfClient.ServiceReference2;
namespace WpfClient
{
    /// <summary>
    /// Logika interakcji dla klasy BotWindoww.xaml
    /// </summary>
    public partial class BotWindow : Window
    {
        static Service1Client client = new Service1Client();
        public BotWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client.RecoFromMicrophoneAsync().Wait();
            DetectedText.Text = client.GetDetectedText();
            if(DetectedText.Text != null && DetectedText.Text != "")
                AnswerText.Text = client.GetDialogFlowAnswer(DetectedText.Text);
        }
    }
}
