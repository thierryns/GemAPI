using GemAPI.BLL;
using GemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace GemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyController : ControllerBase
    {

        private readonly ILogger<EnergyController> _logger;
        ICalculator _calculator;
        public EnergyController(ILogger<EnergyController> logger, ICalculator calculator)
        {
            _calculator = calculator;

            _logger = logger;
            _logger.LogDebug(1, "NLog injected into EnergyController");
        }

        [HttpPost("/productionplan")]
        public IActionResult Get(Payload model)
        {

            _logger.LogInformation("Trying calculator");

            var results = _calculator.OptimizeProduction(model);
            _logger.LogInformation(2, "OPT Results {@results}", results);
           
            return Ok(results);
        }
    }
}
