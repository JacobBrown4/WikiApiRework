using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using WikiAPI.Models.Subcontent;
using WikiAPI.Services;

namespace WikiAPI.Controllers
{
    public class SubcontentController : ApiController
    {
        [Authorize]
        public class StudentController : ApiController
        {
            private SubcontentService CreateSubcontentService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var subcontentService = new SubcontentService(userId);
                return subcontentService;
            }
            public IHttpActionResult Get()
            {
                SubcontentService subcontentService = CreateSubcontentService();
                var subcontents = subcontentService.GetSubcontents();
                return Ok(subcontents);
            }
            public IHttpActionResult Post(SubcontentCreate subcontent)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateSubcontentService();

                if (!service.CreateSubcontent(subcontent))
                    return InternalServerError();

                return Ok();
            }
            public IHttpActionResult Get(int id)
            {
                SubcontentService subcontentService = CreateSubcontentService();
                var subcontent = subcontentService.GetSubcontentById(id);
                return Ok(subcontent);
            }

            public IHttpActionResult Put(SubcontentEdit subcontent)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateSubcontentService();

                if (!service.UpdateSubcontent(subcontent))
                    return InternalServerError();
                return Ok();
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateSubcontentService();

                if (!service.DeleteSubcontent(id))
                    return InternalServerError();
                return Ok();
            }
        }
    }
}
