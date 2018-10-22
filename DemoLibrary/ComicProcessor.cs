using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ComicProcessor
    {
        public int MaxComicNumber { get; set; }

        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {
            string url = "";

            if (comicNumber > 0)
            {
                url = $"https://xkcd.com/{comicNumber}/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }

            // this helps us dispose of things properly
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                // when finished, it will close everything down related to "response"
                // because we dont want to leave ports open, and open up ports all the time

                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>(); // ReadAsAsync uses the NewtonSoft Json converter which will try and map to our model
                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
