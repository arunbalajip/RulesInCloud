using Microsoft.AspNetCore.Mvc;
using RulesInCloud.Models;
using RulesInCloud.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RulesInCloud.Controllers
{
    public class LoadController : Controller
    {
        private readonly XmlDataRepository xmlDataRepository;
        public LoadController(XmlDataRepository xmlDataRepository)
        {
            this.xmlDataRepository = xmlDataRepository;
        }

        [Route("load/{name}")]
        [HttpGet]
        public async Task<ActionResult> LoadXMLByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return NotFound();
            XMLData data = await xmlDataRepository.GetXmlDataByName(name);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [Route("load")]
        [HttpGet]
        public async Task<ActionResult> LoadAllName()
        {
            List<XMLData> data = await xmlDataRepository.GetAllXmlData();
            if(data == null || data.Count == 0)
                return NotFound();
            List<string> names = new();
            foreach(XMLData xml in data)
            {
                names.Add(xml.name);
            }
            return Ok(names);
        }
    }
}
