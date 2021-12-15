using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Models.Subcontent;

namespace WikiAPI.Models.Content
{
    public class ContentDetail
    {
        public int ContentId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; }

        public List<SubcontentListItem> Subcontents { get; set; }
    }
}
