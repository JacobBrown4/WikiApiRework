using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WikiAPI.Models.Content;
using WikiAPI.Services;

namespace WikiAPI.Controllers
{
    [Authorize]
    public class ContentController : ApiController
    {
        private ContentService CreateContentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var contentService = new ContentService(userId);
            return contentService;
        }
        public IHttpActionResult Get()
        {
            ContentService contentService = CreateContentService();
            var contents = contentService.GetContents();
            return Ok(contents);
        }
        public IHttpActionResult Post(ContentCreate content)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContentService();

            if (!service.CreateContent(content))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            ContentService contentService = CreateContentService();
            var content = contentService.GetContentById(id);
            return Ok(content);
        }
        public IHttpActionResult Put(ContentEdit content)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContentService();

            if (!service.UpdateContent(content))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateContentService();

            if (!service.DeleteContent(id))
                return InternalServerError();

            return Ok(); 
        }

    }
}
