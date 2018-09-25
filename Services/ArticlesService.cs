using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NYTWebApi.Models;
using System.Web.Http;
using Microsoft.Extensions.Configuration;

namespace NYTWebApi.Services
{
    public class ArticlesService
    {
        public async Task<List<Doc>> GetjsonAsync(string theme, string begin_date, string end_date,IConfiguration configuration)
        {
            string urlConfig = configuration.GetSection("MySettings").GetSection("url").Value;
            Console.WriteLine(urlConfig);
            string apiConfig = configuration.GetSection("MySettings").GetSection("api_key").Value;
            Console.WriteLine(apiConfig);
            var url = $"{urlConfig}{apiConfig}";

            var list_of_fields = "web_url,snippet,headline,pub_date";
            var orderBy = "newest";

         //   var urlService = new UrlService();
         //   var url = urlService.getUrl();
            var urlComplete = $"{url}&q={theme}&begin_date={begin_date}&end_date={end_date}&fl={list_of_fields}&sort={orderBy}";
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(urlComplete);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException)
            {

                response.StatusCode = HttpStatusCode.ServiceUnavailable;

            }
            string responseBody = await response.Content.ReadAsStringAsync();
            RootObj rootObj = JsonConvert.DeserializeObject<RootObj>(responseBody);

            //keep first 10
            rootObj.response.docs = rootObj.response.docs.Take(10);

            //request a la url de cada article
            foreach (var article in rootObj.response.docs)
            {
                var hc = new HttpClient();
                try
                {
                    response = await hc.GetAsync(article.web_url);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException)
                {
                    article.web_url = "";
                }
            }
            return rootObj.response.docs.ToList();
        }
    }

    // public class NYtimesBroken : Exception
    // {
    //     public NYtimesBroken(string message)
    //        : base(message)
    //     {
    //     }
    // }
}