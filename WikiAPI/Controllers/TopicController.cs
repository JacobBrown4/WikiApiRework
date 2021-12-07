using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WikiAPI.Services;

namespace WikiAPI.Controllers
{
    [Authorize]
    public class TopicController : ApiController
    {
        private TopicService CreateTopicService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var topicService = new TopicService(userId);
            return topicService;
        }
        public IHttpActionResult Get()
        {
            TopicService topicService = CreateTopicService();
            var topic = new TopicService.GetTopic();
            return Ok(topic);
        }
    }
}
