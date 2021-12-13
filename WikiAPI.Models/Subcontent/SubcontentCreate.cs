using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Subcontent
{
    public class SubcontentCreate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        public int ContentId { get; set; }
    }
}
