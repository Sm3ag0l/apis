using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation(int comicNumber = 0)
        {
            string url = "https://api.sunrise-sunset.org/json?lat=41.494804&lng=-75.536852&date=today";

            // this helps us dispose of things properly
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                // when finished, it will close everything down related to "response"
                // because we dont want to leave ports open, and open up ports all the time

                if (response.IsSuccessStatusCode)
                {
                    SunResultModel results = await response.Content.ReadAsAsync<SunResultModel>(); // ReadAsAsync uses the NewtonSoft Json converter which will try and map to our model
                    return results.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
