using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Topic
{
    public class TopicEdit
    {
        [Required]
        public int TopicId { get; set; }
        [Required]
        public string TopicTitle { get; set; }
        [Required]
        public string Summary { get; set; }
    }
}
