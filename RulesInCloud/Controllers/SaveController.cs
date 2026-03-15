using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesInCloud.Models;
using RulesInCloud.Repositories;
using System.Threading.Tasks;

namespace RulesInCloud.Controllers
{
    public class SaveController : Controller
    {
        private readonly XmlDataRepository xmlDataRepository;
        private readonly ILogger<SaveController> _logger;

        public SaveController(XmlDataRepository xmlDataRepository, ILogger<SaveController> logger)
        {
            this.xmlDataRepository = xmlDataRepository;
            _logger = logger;
        }

        /// <summary>Creates a new rule. Returns 409 if a rule with the same name already exists.</summary>
        [Route("savexml")]
        [HttpPost]
        public async Task<ActionResult> SaveXML([FromBody] InputRequestModel input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.name) || string.IsNullOrWhiteSpace(input.value))
                return BadRequest(new ErrorModel { ErrorMessage = "name and value are required." });

            XMLData data = await xmlDataRepository.GetXmlDataByName(input.name);
            if (data != null)
            {
                _logger.LogWarning("Rule '{Name}' already exists; skipping save.", input.name);
                return Conflict(new ErrorModel { ErrorMessage = $"A rule named '{input.name}' already exists." });
            }

            await xmlDataRepository.SaveXMLData(input.name, input.value);
            _logger.LogInformation("Saved rule '{Name}'.", input.name);
            return Ok();
        }

        /// <summary>Updates the value of an existing rule by name.</summary>
        [Route("savexml/{name}")]
        [HttpPut]
        public async Task<ActionResult> UpdateXML(string name, [FromBody] InputRequestModel input)
        {
            if (string.IsNullOrWhiteSpace(name) || input == null || string.IsNullOrWhiteSpace(input.value))
                return BadRequest(new ErrorModel { ErrorMessage = "name and value are required." });

            XMLData data = await xmlDataRepository.GetXmlDataByName(name);
            if (data == null)
            {
                _logger.LogWarning("Rule '{Name}' not found for update.", name);
                return NotFound(new ErrorModel { ErrorMessage = $"Rule '{name}' not found." });
            }

            await xmlDataRepository.UpdateXMLData(data, input.value);
            _logger.LogInformation("Updated rule '{Name}'.", name);
            return Ok();
        }
    }
}
