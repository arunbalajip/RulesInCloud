using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RulesEngine.Models;
using RulesInCloud.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;

namespace RulesInCloud.Controllers
{
    public class TestController : Controller
    {
        private readonly ExpandoObjectConverter expandObject;
        public TestController()
        {
            expandObject = new ExpandoObjectConverter();
        }

        [Route("testData")]
        [HttpPost]
        public ActionResult TestData([FromBody] TestRequestModel requestModel)
        {
            if (requestModel == null || string.IsNullOrWhiteSpace(requestModel.ruleData) || string.IsNullOrWhiteSpace(requestModel.input))
                return NotFound();

            try
            {
                Workflow workflow = JsonConvert.DeserializeObject<Workflow>(requestModel.ruleData);
                workflow.WorkflowName ??= "User Workflow";
                Workflow[] workflows = new Workflow[1];
                workflows[0] = workflow;

                var bre = new RulesEngine.RulesEngine(workflows, null);
                List<RuleResultTree> resultList = bre.ExecuteAllRulesAsync(workflow.WorkflowName,
                    JsonConvert.DeserializeObject<ExpandoObject[]>(requestModel.input, expandObject)).Result;

                List<Rule> list = new();
                foreach (RuleResultTree tree in resultList)
                {
                    if (tree.IsSuccess)
                        list.Add(tree.Rule);
                }
                if (list.Count > 0)
                    return Ok(list);
            }
            catch (Exception ex){
                return Ok(new ErrorModel
                {
                    ErrorMessage = ex.Message
                });
            }

            return Ok(new ErrorModel
            {
                ErrorMessage =  "No matching rules"
            });
        }
    }
}
