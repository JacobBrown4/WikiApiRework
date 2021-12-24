using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Topic
{
    public class TopicCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "There aren't enough characters in this field")]
        public string TopicTitle { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "There aren't enough characters in this field")]
        public string Summary { get; set; }
    }
}
