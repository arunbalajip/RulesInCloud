using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesInCloud.Models;
using RulesInCloud.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RulesInCloud.Controllers
{
    public class LoadController : Controller
    {
        private readonly XmlDataRepository xmlDataRepository;
        private readonly ILogger<LoadController> _logger;

        public LoadController(XmlDataRepository xmlDataRepository, ILogger<LoadController> logger)
        {
            this.xmlDataRepository = xmlDataRepository;
            _logger = logger;
        }

        [Route("load/{name}")]
        [HttpGet]
        public async Task<ActionResult> LoadXMLByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new ErrorModel { ErrorMessage = "name is required." });

            XMLData data = await xmlDataRepository.GetXmlDataByName(name);
            if (data == null)
            {
                _logger.LogWarning("Rule '{Name}' not found.", name);
                return NotFound(new ErrorModel { ErrorMessage = $"Rule '{name}' not found." });
            }
            return Ok(data);
        }

        [Route("load")]
        [HttpGet]
        public async Task<ActionResult> LoadAllName()
        {
            List<XMLData> data = await xmlDataRepository.GetAllXmlData();
            if (data == null || data.Count == 0)
                return Ok(new List<string>());

            List<string> names = new();
            foreach (XMLData xml in data)
            {
                names.Add(xml.name);
            }
            return Ok(names);
        }
    }
}
