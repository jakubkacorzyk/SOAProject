using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ApiAiSDK;
using ApiAiSDK.Model;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VoiceTest
{
    class Program
    {
        private static ApiAi apiAi;
        private static readonly HttpClient client = new HttpClient();
        public static string GetDialogFlowAnswer(string message)
        {
            var config = new AIConfiguration("564e2b6d00424a6ab05ba53cd57b585c", SupportedLanguage.English);

            apiAi = new ApiAi(config);

            var responseString = apiAi.TextRequest(message);

            return responseString.Result.Fulfillment.Speech;
        }

        static async Task RecoFromMicrophoneAsync()
        {
            var subscriptionKey = "a83dbe5e00c94e7dad4be7786dc32252";
            var region = "westus";

            var factory = SpeechFactory.FromSubscription(subscriptionKey, region);

            using (var recognizer = factory.CreateSpeechRecognizer())
            {
                Console.WriteLine("Say something...");
                var result = await recognizer.RecognizeAsync();

                if (result.RecognitionStatus != RecognitionStatus.Recognized)
                {
                    Console.WriteLine($"There was an error, status {result.RecognitionStatus.ToString()}, reason {result.RecognitionFailureReason}");
                }
                else
                {
                    Console.WriteLine($"We recognized: {result.Text}");
                }
                if (result.Text != "" && result.Text != null)
                {
                    Console.WriteLine("DialogFlow answer :");
                    Console.Write(GetDialogFlowAnswer(result.Text));
                    Console.WriteLine();
                }
                Console.WriteLine("Please press a key to continue.");
                Console.ReadKey();
            }
        }
        public static string WeatherTest()
        {
            HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=Krakow&APPID=2a41ea917fe0ea8071a1f776745a4154");
            GETRequest.Method = "GET";
            HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
            Stream GETResponseStream = GETResponse.GetResponseStream();
            StreamReader sr = new StreamReader(GETResponseStream);

            Console.WriteLine("Response from Server");
            dynamic stuff = JObject.Parse(sr.ReadToEnd());
                return stuff.name;
        }

        public static string QuotesTest()
        {
            HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create("https://talaikis.com/api/quotes/random/");
            GETRequest.Method = "GET";
            HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
            Stream GETResponseStream = GETResponse.GetResponseStream();
            StreamReader sr = new StreamReader(GETResponseStream);

            Console.WriteLine("Response from Server");
            dynamic stuff = JObject.Parse(sr.ReadToEnd());
            return stuff.quote;
        }



        static void Main(string[] args)
        {
            //RecoFromMicrophoneAsync().Wait();
            Console.WriteLine(WeatherTest());
    
            Console.WriteLine(QuotesTest());
            Console.ReadKey();
        }

    }
}

