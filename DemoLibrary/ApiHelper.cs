using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DemoLibrary
{
    public static class ApiHelper
    {
        // its going to help us create the basic needs for our two APIs (comic and weather)

        // static because the fact of that we want to open once per app - it uses TCP/IP port 
        // its also thread safe, and setup to do multiple concurrent calls when static
        public static HttpClient ApiClient { get; set; } 

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri("http://xkcd.com"); // we could use a base address if we were only using one API
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
