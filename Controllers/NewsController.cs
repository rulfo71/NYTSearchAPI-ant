using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NYTWebApi.Models;
using NYTWebApi.Services;

namespace NYTWebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        //localhost:1233/NombreDelControlador/nombreDelMetodo
        //GET /values
        [HttpGet]
        public async Task<RootObj> GetAsync()
        {
            string theme = HttpContext.Request.Query["theme"].ToString();
            string begin_date = HttpContext.Request.Query["begin_date"].ToString();
            string end_date = HttpContext.Request.Query["end_date"].ToString();

            return await ArticlesService.getjsonAsync(theme, begin_date, end_date);
        }


        // [HttpPost]
        // public void Post(SearchQuery query)
        // {
        //     // Console.WriteLine("****");
        //     // Console.WriteLine("****");
        //     // Console.WriteLine("****");
        //     // Console.WriteLine(query.Theme);
        //     // Console.WriteLine(query.Begin_date);
        //     // Console.WriteLine(query.End_date);
        //     // Console.WriteLine("****");
        //     // Console.WriteLine("****");
        //     // Console.WriteLine("****");

        //     this.query = new SearchQuery(query.Theme, query.Begin_date, query.End_date);
        //     Console.WriteLine("**********" + this.query.Theme);
        // }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "valuuuue";
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
