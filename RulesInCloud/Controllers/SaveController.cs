using Microsoft.AspNetCore.Mvc;
using RulesInCloud.Models;
using RulesInCloud.Repositories;
using System.Threading.Tasks;

namespace RulesInCloud.Controllers
{
    public class SaveController : Controller
    {
        private readonly XmlDataRepository xmlDataRepository;
        public SaveController(XmlDataRepository xmlDataRepository)
        {
            this.xmlDataRepository = xmlDataRepository;
        }

        [Route("savexml")]
        [HttpPost]
        public async Task<ActionResult> SaveXML([FromBody] InputRequestModel input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.name) || string.IsNullOrWhiteSpace(input.value))
                return NotFound();

            XMLData data = await xmlDataRepository.GetXmlDataByName(input.name);
            if (data == null)
            {
                await xmlDataRepository.SaveXMLData(input.name, input.value);
            }
            return Ok();
        }
    }
}