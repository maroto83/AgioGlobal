using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AgioGlobal.Client.Presentation.Website.Helpers
{
    public static class MyHelper
    {
        //Hosted web API REST Service base url  
        public static string BaseUrl { get; set; } = "http://localhost:50330/";

        public static HttpClient HttpClient
        {
            get
            {
                //Passing service base url  
                var client = new HttpClient {BaseAddress = new Uri(BaseUrl)};

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            }
        }
    }
}