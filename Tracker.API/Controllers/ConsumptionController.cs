using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Tracker.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ConsumptionController : ControllerBase
    {
        private static List<string> Summaries = new List<string>{};

        private readonly ILogger<ConsumptionController> _logger;

        public ConsumptionController(ILogger<ConsumptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            _logger.LogInformation("Call Consumption GetAll method");
            return new JsonResult(Summaries);
        }

        [HttpGet]
        public ActionResult Get([FromQuery][Required] string refNo)
        {
            _logger.LogInformation($"Call Consumption Get method: RefNo = {refNo}");
            return new JsonResult(Summaries.FirstOrDefault(x => x == refNo));
        }

        [HttpGet]
        public ActionResult Delete([FromQuery][Required] string refNo)
        {
            _logger.LogInformation($"Delete Consumption RefNo = {refNo}");
            return new JsonResult(Summaries.Remove(refNo));
        }

        [HttpGet]
        public ActionResult Insert([FromQuery][Required] string refNo)
        {
            _logger.LogInformation($"Insert Consumption RefNo = {refNo}");
            Summaries.Add(refNo);
            return new JsonResult(Summaries);
        }
    }
}
