using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models
{
    public class ContentDisplay
    {
        public string Title { get; set; }
        public List<SubcontentDisplay> Subcontents { get; set; } 
    }
}
