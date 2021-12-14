using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Models.Topic;

namespace WikiAPI.Models.Content
{
    public class ContentCreate
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Title { get; set; }
        public int TopicId { get; set; }
    }
}
