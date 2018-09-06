using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NYTWebApi.Models;

namespace NYTWebApi.Services
{
    public static class ArticlesService
    {
        public static async Task<RootObject> getjsonAsync()
        {
            var url = "https://api.nytimes.com/svc/search/v2/articlesearch.json?api-key=0e73567c463040c6a9e0e115a807f993&q=argentina&begin_date=20160901&end_date=20160902&fl=web_url%2Csnippet%2Cheadline%2Cpub_date";
            var hc = new HttpClient();
            HttpResponseMessage response = await hc.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            RootObject rootObj = JsonConvert.DeserializeObject<RootObject>(responseBody);
            return rootObj;
        }
    }
}