using System;
using System.Collections.Generic;
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
        public ActionResult Get(string refNo)
        {
            ValidateRefNo(refNo);
            _logger.LogInformation($"Call Consumption Get method: RefNo = {refNo}");
            return new JsonResult(Summaries.FirstOrDefault(x => x == refNo));
        }

        [HttpGet]
        public ActionResult Delete(string refNo)
        {
            ValidateRefNo(refNo);
            _logger.LogInformation($"Delete Consumption RefNo = {refNo}");
            return new JsonResult(Summaries.Remove(refNo));
        }

        [HttpGet]
        public ActionResult Insert(string refNo)
        {
            ValidateRefNo(refNo);
            _logger.LogInformation($"Insert Consumption RefNo = {refNo}");
            Summaries.Add(refNo);
            return new JsonResult(Summaries);
        }

        private void ValidateRefNo(string refNo)
        {
            if (string.IsNullOrEmpty(refNo))
            {
                throw new Exception($"Invalid RefNo = {refNo}");
            }
        }
    }
}
