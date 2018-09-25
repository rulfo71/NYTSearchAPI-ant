using System;
using Microsoft.Extensions.Configuration;
namespace NYTWebApi.Services
{
    public class UrlService
    {
        // private IConfiguration configuration;
        // public UrlService(IConfiguration iConfig)
        // {
        //     configuration = iConfig;
        // }
        // public string getUrl()
        // {
        //     string urlConf = configuration.GetSection("MySettings").GetSection("url").Value;
        //     string apiConf = configuration.GetSection("MySettings").GetSection("api_key").Value;
        //     Console.WriteLine($"{urlConf}{apiConf}");

        //     return $"{urlConf}{apiConf}";

        // var api_key = "0e73567c463040c6a9e0e115a807f993";
        // var url = $"http://api.nytimes.com/svc/search/v2/articlesearch.json?api-key={api_key}";
        // return url;
        // }

    }
}