using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NYTWebApi.Models;
using NYTWebApi.Services;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Globalization;
using System.Linq;

namespace NYTWebApi.Controllers
{
    //[Route("api/[controller]")]

    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private IConfiguration configuration;
        private List<Doc> ListOfArticles = new List<Doc>();
        private ExceptionsList listOfExceptions = new ExceptionsList();
        private ArticlesService ArticlesService;
        private QueryValidator Validator;
        public NewsController(IConfiguration iConfig)
        {
            configuration = iConfig;
            this.ArticlesService = new ArticlesService(this.configuration);
            this.Validator = new QueryValidator();
        }
        //GET /values
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Doc>))]
        [ProducesResponseType(422)]
        [ProducesResponseType(504)]
        public async Task<ActionResult> GetAsync([FromQuery] NewsUrlParameters FilterParams)
        {
            listOfExceptions = this.Validator.ValidateData(FilterParams.Theme, FilterParams.Begin_date, FilterParams.End_date);
            if (listOfExceptions.listOfExceptions.Any())
            {
                listOfExceptions.PrepareMessage();
                return new UnprocessableEntityObjectResult(listOfExceptions.Messages);
            }
            try
            {
                this.ListOfArticles = await this.ArticlesService.GetNewsAsync(FilterParams.Theme, FilterParams.Begin_date, FilterParams.End_date);
            }
            catch (HttpRequestException)
            {
                return StatusCode(503);
            }
            return Ok(this.ListOfArticles);
        }
    }
}