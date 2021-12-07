using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WikiAPI.Models.Topic;
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
            var topic = topicService.GetTopic();
            return Ok(topic);
        }
        public IHttpActionResult Post(TopicCreate topic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTopicService();

            if (!service.CreateTopic(topic))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            TopicService topicService = CreateTopicService();
            var topic = topicService.GetTopicById(id);
            return Ok(topic);
        }
        public IHttpActionResult Put(TopicEdit topic)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateTopicService();

            if (!service.UpdateTopic(topic))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTopicService();

            if (!service.DeleteTopic(id))
                return InternalServerError();
            return Ok();

        }
    } 
}
