using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAPI.Models
{
    public class TopicDisplay
    {
        public string TopicTitle { get; set; }

        public string Summary { get; set; }

        public List<ContentDisplay> Contents { get; set; }
    }
}
