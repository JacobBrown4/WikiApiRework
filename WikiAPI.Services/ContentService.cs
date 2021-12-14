using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Data;
using WikiAPI.Models.Content;
using WikiAPI.Models.Subcontent;

namespace WikiAPI.Services
{
    public class ContentService
    {
        private readonly Guid _userId;

        public ContentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateContent(ContentCreate contentmodel)
        {
            var entity = new Content()
            {
                ContentId = contentmodel.ContentId,
                Title = contentmodel.Title,
                CreatedAt = DateTime.Now,
                TopicId = contentmodel.TopicId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ContentListItem> GetContents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Contents
                    .AsEnumerable()
                    .Select(e => new ContentListItem
                    {
                        ContentId = e.ContentId,
                        Title = e.Title,
                        CreatedAt = e.CreatedAt
                    }
                    );
                return query.ToArray();
            }
        }
        public ContentDetail GetContentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Contents
                    .Single(e => e.ContentId == id);
                return
                new ContentDetail
                {
                    ContentId = entity.ContentId,
                    Title = entity.Title,
                    CreatedAt = entity.CreatedAt,
                    Subcontents = entity.Subcontents.Select(x => new SubcontentListItem()
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Summary = x.Summary
                    }).ToList()
                };
            }
        }
        public bool UpdateContent(ContentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Contents
                    .Single(e => e.ContentId == model.ContentId);
                entity.Title = model.Title;

                return ctx.SaveChanges() == 1; 
            }
        }

        public bool DeleteContent(int contentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Contents
                    .Single(e => e.ContentId == contentId);

                    ctx.Contents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

