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
        private IConfiguration configuration;
        private HttpClient httpClient;
        private HttpResponseMessage response;

        private QueryValidator validator;
        public ArticlesService(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
        }
        public async Task<List<Doc>> GetNewsAsync(string theme, string begin_date, string end_date)
        {
            validator = new QueryValidator(theme,begin_date,end_date);
            string urlConfig = configuration.GetSection("MySettings").GetSection("url").Value;
            Console.WriteLine(urlConfig);
            string apiConfig = configuration.GetSection("MySettings").GetSection("api_key").Value;
            Console.WriteLine(apiConfig);
            var url = $"{urlConfig}{apiConfig}";

            var list_of_fields = "web_url,snippet,headline,pub_date";
            var orderBy = "newest";
            
            validator.validateData();

            var urlComplete = $"{url}&q={theme}&begin_date={begin_date}&end_date={end_date}&fl={list_of_fields}&sort={orderBy}";

            response = await httpClient.GetAsync(urlComplete);
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

            await this.checkUrlsStatusAsync(rootObj);
            return rootObj.response.docs.ToList();
        }
        private async Task checkUrlsStatusAsync(RootObj rootObj)
        {
            foreach (var article in rootObj.response.docs)
            {
                try
                {
                    this.response = await httpClient.GetAsync(article.web_url);
                    this.response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException)
                {
                    article.web_url = "";
                }
            }
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