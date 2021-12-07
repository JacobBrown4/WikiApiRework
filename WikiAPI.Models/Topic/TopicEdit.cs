using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Topic
{
    public class TopicEdit
    {
        public int TopicId { get; set; }
        public string TopicTitle { get; set; }
        public string Summary { get; set; }
    }
}
