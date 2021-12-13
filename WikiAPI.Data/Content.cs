using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Data
{
   public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        public virtual List<Subcontent> Subcontents { get; set; } = new List<Subcontent>();
        public int TopicId { get; set; }
    }
}
