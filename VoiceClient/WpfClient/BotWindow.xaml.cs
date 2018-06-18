using Newtonsoft.Json.Linq;
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
using WpfClient.ServiceReference1;
using WpfClient.ServiceReference2;
using WpfClient.ServiceReference3;
using System.Text.RegularExpressions;
namespace WpfClient
{
    /// <summary>
    /// Logika interakcji dla klasy BotWindoww.xaml
    /// </summary>
    public partial class BotWindow : Window
    {
        static ServiceReference2.Service1Client client = new ServiceReference2.Service1Client();
        static ServiceReference3.Service1Client weatherClient = new ServiceReference3.Service1Client();
        static ServiceReference1.Service1Client quotesClient = new ServiceReference1.Service1Client();
        int MessageCount = 0;

        public BotWindow()
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //AnswerText.Text += "\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
       
            client.RecoFromMicrophoneAsync().Wait();
            string detected = client.GetDetectedText();
            DetectedText.Text += "– " + detected + "\n\n";
            AnswerText.Text += "– " + client.GetDialogFlowAnswer(detected) + "\n\n";
            MessageCount++;
            if (MessageCount > 4) CleanMessages();
        }

        private void CleanMessages()
        {
            DetectedText.Text = Regex.Replace(DetectedText.Text, @"– .*\n\n–", "");
            AnswerText.Text = Regex.Replace(AnswerText.Text, @"– .*\n\n–", "");

            DetectedText.Text = "–" + DetectedText.Text;
            AnswerText.Text = "–" + AnswerText.Text;

            MessageCount--;
        }
        
        private void button_weather_Click(object sender, RoutedEventArgs e)
        {
            string reader = weatherClient.GetWeatherData(city.Text);
            dynamic stuff = JObject.Parse(reader);
            Weather.Text = " City: " + stuff.name + "\n Temperature: " + (stuff.main.temp -273.15) + " °C \n Humidity: " + (stuff.main.humidity) + " % \n Wind's speed: " + (stuff.wind.speed) + " km/h \n Cloudiness: " + (stuff.clouds.all) +" %";
        } 
        
        private void quote_button_Click(object sender, RoutedEventArgs e)
        {
            string reader = quotesClient.GetRandomQuote();
            dynamic stuff = JObject.Parse(reader);
            quote.Text = "Category: " + stuff.cat + "\n\nAuthor: " + stuff.author + "\n\nQuote: " + stuff.quote;
        }
    }
}
