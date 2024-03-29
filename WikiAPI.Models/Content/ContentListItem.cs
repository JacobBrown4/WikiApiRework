﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Models.Topic;

namespace WikiAPI.Models.Content
{
    public class ContentListItem
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        [Display(Name ="Created" )]
        public DateTime CreatedAt { get; set; }
        public List<string> Subcontents { get; set; }
    }
}
