using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Content
{
    public class ContentCreate
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Title { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Topic { get; set; }





    }
}
