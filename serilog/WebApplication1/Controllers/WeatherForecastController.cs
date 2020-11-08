using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase

    {
        private readonly ILogger<WeatherForecastController> _logger;
       
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get method");


            int count;
            try
            {
                for (count = 0; count <= 5; count++)
                {
                    if (count == 3)
                    {
                        throw new Exception("RandomException");
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return BadRequest();
            }
        }
    }
}

