using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Data;
using WikiAPI.Models.Subcontent;

namespace WikiAPI.Services
{
    public class SubcontentService
    {
        private readonly Guid _userId;

        public SubcontentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateSubcontent(SubcontentCreate subcontentmodel)
        {
            var entity = new Subcontent()
            {
                Id = subcontentmodel.Id,
                Title = subcontentmodel.Title,
                CreatedAt = DateTime.Now,
                Summary = subcontentmodel.Summary,
                Content = subcontentmodel.Content
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Subcontents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SubcontentListItem> GetSubcontents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Subcontents.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new SubcontentListItem
                        {
                            Id = e.Id,
                            Title = e.Title,
                            CreatedAt = e.CreatedAt
                        }
                        );
                return query.ToArray();
            }
        }
        public SubcontentDetail GetSubcontentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Subcontents
                    .Single(e => e.Id == id && e.OwnerId == _userId);
                return
                    new SubcontentDetail()
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        CreatedAt = entity.CreatedAt,
                        Summary = entity.Summary,
                        Content = entity.Content
                    };
            }
        }
        public bool UpdateSubcontent(SubcontentEdit subcontentmodel)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Subcontents
                    .Single(e => e.Id == subcontentmodel.Id);
                entity.Title = subcontentmodel.Title;
                entity.CreatedAt = DateTime.Now;
                entity.Summary = subcontentmodel.Summary;
                entity.Content = subcontentmodel.Content;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteSubcontent(int subcontentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Subcontents
                    .Single(e => e.Id ==  subcontentId);
                ctx.Subcontents.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
