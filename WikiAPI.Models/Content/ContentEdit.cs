using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Content
{
    public class ContentEdit
    {
        [Required]
        public int ContentId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
