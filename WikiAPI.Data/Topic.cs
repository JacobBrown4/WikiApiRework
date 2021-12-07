using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Data
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        [Required]
        public string TopicTitle { get; set; }
        [Required]
        public string  Summary { get; set; }
        [Required]
        public DateTime TopicCreatedAt { get; set; }
        //[Required]
        //public Dictionary<String sidebar> Sidebar { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
    }
}
