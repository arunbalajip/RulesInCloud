using System.ComponentModel.DataAnnotations;

namespace RulesInCloud.Models
{
    public class TestRequestModel
    {
        [Required]
        public string ruleData { get; set; }

        [Required]
        public string input { get; set; }
    }
}
