using System.ComponentModel.DataAnnotations;

namespace RulesInCloud.Models
{
    public class InputRequestModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string value { get; set; }
    }
}
