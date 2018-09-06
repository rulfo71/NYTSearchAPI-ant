using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NYTWebApi.Services
{
    public class getArticlesService
    {
        async Task<int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();
            //Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            string urlContents = await client.GetStringAsync("http://msdn.microsoft.com");  
            //console.log("Independent work");
            //string urlContents = await getStringTask;
            Console.WriteLine(urlContents);
            return urlContents.Length;
        }
    }
}