using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Data
{
    class Content
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public string Summary { get; set; }
        [ForeignKey("Topic")] 
        public int topicID { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public int Author_Id { get; set; }

    }
}
