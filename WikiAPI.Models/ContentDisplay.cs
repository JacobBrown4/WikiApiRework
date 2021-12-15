using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models
{
    public class ContentDisplay
    {
        [Display(Name ="Content Title")]
        public string Title { get; set; }
        [Display(Name = "Subcontent Title/Summary")]
        public List<SubcontentDisplay> Subcontents { get; set; } 
    }
}
