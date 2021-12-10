using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Data
{
    public class Subcontent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Summary { get; set; }
        [ForeignKey("Content")]
        public int ContentId { get; set; }
        public Content Content { get; set; }
        public Guid OwnerId { get; set; }
    }
}
