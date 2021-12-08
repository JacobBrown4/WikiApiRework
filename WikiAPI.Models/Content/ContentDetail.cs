﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Content
{
    public class ContentDetail
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedAt { get; set; }
        public string Topic { get; set; }
    }
}
