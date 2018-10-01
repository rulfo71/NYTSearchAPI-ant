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

        public ArticlesService(IConfiguration configuration)
        {
            this.configuration = configuration;
            httpClient = new HttpClient();
        }
        public async Task<List<Doc>> GetNewsAsync(string theme, string begin_date, string end_date)
        {
            string urlConfig = configuration.GetSection("MySettings").GetSection("url").Value;
            string apiConfig = configuration.GetSection("MySettings").GetSection("api_key").Value;
            var url = $"{urlConfig}{apiConfig}";
            var list_of_fields = "web_url,snippet,headline,pub_date";
            var orderBy = "newest";
            var urlComplete = $"{url}&q={theme}&begin_date={begin_date.ToString()}&end_date={end_date.ToString()}&fl={list_of_fields}&sort={orderBy}";
            response = await httpClient.GetAsync(urlComplete);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException exception)
            {
                throw exception;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            RootObj rootObj = JsonConvert.DeserializeObject<RootObj>(responseBody);

            rootObj.response.docs = this.KeepFirstArticles(rootObj.response.docs, 10);

            await this.CheckUrlsStatusAsync(rootObj);
            return rootObj.response.docs.ToList();
        }
        public IEnumerable<Doc> KeepFirstArticles(IEnumerable<Doc> docs, int numberOfArticles){
            return docs.Take(numberOfArticles);
        }
        private async Task CheckUrlsStatusAsync(RootObj rootObj)
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
}