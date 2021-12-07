using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models.Topic
{
    public class TopicListItem
    {
        public int TopicId { get; set; }
        public int TopicTitle { get; set; }
        public DateTime TopicCreatedAt { get; set; }
    }
}
