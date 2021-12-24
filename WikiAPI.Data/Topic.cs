using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual List<Content> Contents { get; set; } = new List<Content>();
        [Required]
        public Guid Author { get; set; }

    }
}
