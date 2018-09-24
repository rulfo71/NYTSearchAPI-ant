using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NYTWebApi.Models;
using NYTWebApi.Services;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace NYTWebApi.Controllers
{
    //[Route("api/[controller]")]

    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        //GET /values
        [HttpGet]
        public async Task<List<Doc>> GetAsync([FromQuery] UrlParameters FilterParams)
        {
            var articlesService = new ArticlesService();
            return await articlesService.GetjsonAsync(FilterParams.Theme, FilterParams.Begin_date, FilterParams.End_date);
        }
    }

}
