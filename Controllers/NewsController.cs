using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NYTWebApi.Models;
using NYTWebApi.Services;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace NYTWebApi.Controllers
{
    //[Route("api/[controller]")]

    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private IConfiguration configuration; 
        public NewsController(IConfiguration iConfig){
            configuration = iConfig; 
        }
        //GET /values
        [HttpGet]
        public async Task<List<Doc>> GetAsync([FromQuery] NewsUrlParameters FilterParams)
        {
            var articlesService = new ArticlesService(this.configuration);
            return await articlesService.GetNewsAsync(FilterParams.Theme, FilterParams.Begin_date, FilterParams.End_date);
        }
    }

}
