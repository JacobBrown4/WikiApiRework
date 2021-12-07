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
        [Key]
        public int TopicId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "There aren't enough characters in this field")]
        public string TopicTitle { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "There aren't enough characters in this field")]
        public string Summary { get; set; }
        [Required]
        public DateTime TopicCreatedAt { get; set; }
        //[Required]
        //public Dictionary<String sidebar> Sidebar { get; set; }
    }
}
