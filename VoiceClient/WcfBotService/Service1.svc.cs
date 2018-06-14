using ApiAiSDK;
using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfBotService
{
 
    public class Service1 : IService1
    {
        public static string text = null;
        private static ApiAi apiAi;
        private static readonly HttpClient client = new HttpClient();
        public string GetDialogFlowAnswer(string message)
        {
            var config = new AIConfiguration("564e2b6d00424a6ab05ba53cd57b585c", SupportedLanguage.English);

            apiAi = new ApiAi(config);

            var responseString = apiAi.TextRequest(message);

            return responseString.Result.Fulfillment.Speech;
        }

        public string GetDetectedText()
        {
            string message = text;
            text = "";
            return message;
            
        }
        public async Task RecoFromMicrophoneAsync()
        {
            var subscriptionKey = "a83dbe5e00c94e7dad4be7786dc32252";
            var region = "westus";

            var factory = SpeechFactory.FromSubscription(subscriptionKey, region);

            using (var recognizer = factory.CreateSpeechRecognizer())
            {
                var result = await recognizer.RecognizeAsync();

                if (result.RecognitionStatus != RecognitionStatus.Recognized)
                {
                    text = ($"There was an error, status {result.RecognitionStatus.ToString()}, reason {result.RecognitionFailureReason}");
                }
                else
                {
                    text = ($"{result.Text}");
                }
            }
        }
    }
}

