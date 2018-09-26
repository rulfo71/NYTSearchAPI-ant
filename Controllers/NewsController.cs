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
        public NewsController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        //GET /values
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Doc>))]
        [ProducesResponseType(422)]
        public async Task<ActionResult> GetAsync([FromQuery] NewsUrlParameters FilterParams)
        {
            var validator = new QueryValidator(FilterParams.Theme, FilterParams.Begin_date, FilterParams.End_date);
            try
            {
                validator.validateData();
            }
            catch (EmptyDataException)
            {
                return new UnprocessableEntityObjectResult("You have to fill the data");
            }
            catch (WrongDatesException) 
            {
                return new UnprocessableEntityObjectResult("End date must be later than Begin Date");
            }

            var articlesService = new ArticlesService(this.configuration);
            return Ok(await articlesService.GetNewsAsync(FilterParams.Theme, FilterParams.Begin_date, FilterParams.End_date));
        }
    }

}
