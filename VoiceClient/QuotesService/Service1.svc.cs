using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QuotesService
{
    public class Service1 : IService1
    {
        public string GetRandomQuote()
        {
            HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create("https://talaikis.com/api/quotes/random/");
            GETRequest.Method = "GET";
            HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
            Stream GETResponseStream = GETResponse.GetResponseStream();
            StreamReader sr = new StreamReader(GETResponseStream);

            return sr.ReadToEnd();
           
        }
    }
}
