using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NYTWebApi.Models;
using NYTWebApi.Services;
using Microsoft.AspNetCore.Cors;

namespace NYTWebApi.Controllers
{
    //[Route("api/[controller]")]

    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        //GET /values
        [HttpGet]
        public async Task<RootObj> GetAsync()
        {
            string theme = HttpContext.Request.Query["theme"].ToString();
            string begin_date = HttpContext.Request.Query["begin_date"].ToString();
            string end_date = HttpContext.Request.Query["end_date"].ToString();

            return await ArticlesService.getjsonAsync(theme, begin_date, end_date);
        }
    }
}
