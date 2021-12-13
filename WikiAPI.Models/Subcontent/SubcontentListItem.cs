using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Subcontent
{
    public class SubcontentListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name ="Created At")]
        public DateTime CreatedAt { get; set; }
        public string Summary { get; set; }
    }
}
