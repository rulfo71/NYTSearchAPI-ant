using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NYTWebApi.Models;

namespace NYTWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //string url = "https://api.nytimes.com/svc/search/v2/articlesearch.json?api-key=0e73567c463040c6a9e0e115a807f993&q=argentina&begin_date=20160901&end_date=20160902&fl=web_url%2Csnippet%2Cheadline%2Cpub_date";
        // static HttpClient client = new HttpClient();
        // static async Task RunAsync()
        // {
        //     // Update port # in the following line.
        //     client.BaseAddress = new Uri("http://localhost:5001/");
        //     client.DefaultRequestHeaders.Accept.Clear();
        //     client.DefaultRequestHeaders.Accept.Add(
        //         new MediaTypeWithQualityHeaderValue("application/json"));
        // }

        // static async Task<string> GetProductAsync(string path)
        // {
        //     string product = null;
        //     HttpResponseMessage response = await client.GetAsync(path);
        //     if (response.IsSuccessStatusCode)
        //     {
        //         product = await response.Content.ReadAsAsync<string>();
        //     }
        //     return product;
        // }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            return new string[] { "valueeee1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "valuuuue";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
