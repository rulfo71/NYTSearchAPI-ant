namespace NYTWebApi.Services
{
    public class UrlService
    {
        public string getUrl()
        {
            var api_key = "0e73567c463040c6a9e0e115a807f993";
            var url = $"http://api.nytimes.com/svc/search/v2/articlesearch.json?api-key={api_key}";
            return url;

        }

    }
}