using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NYTWebApi.Models;

namespace NYTWebApi.Services
{
    public static class ArticlesService
    {
        public static async Task<RootObj> getjsonAsync(string theme, string begin_date, string end_date)
        {
            var list_of_fields = "web_url,snippet,headline,pub_date";
            var api_key = "0e73567c463040c6a9e0e115a807f993";
            var orderBy = "newest";
            var url = "https://api.nytimes.com/svc/search/v2/articlesearch.json?api-key=" + api_key + "&q=" + theme + "&begin_date=" + begin_date + "&end_date=" + end_date + "&fl=" + list_of_fields + "&sort=" + orderBy;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

            RootObj rootObj = JsonConvert.DeserializeObject<RootObj>(responseBody);
            //keep first 10
            rootObj.response.docs = rootObj.response.docs.Take(10);
            
            return rootObj;
        }
    }

}