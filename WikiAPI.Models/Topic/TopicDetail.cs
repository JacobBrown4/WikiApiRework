using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Models.Content;

namespace WikiAPI.Models.Topic
{
    public class TopicDetail
    {

        public int TopicId { get; set; }

        public string TopicTitle { get; set; }

        public string Summary { get; set; }

        public DateTime TopicCreatedAt { get; set; }
        public List<ContentListItem> Contents { get; set; }
    }
}
