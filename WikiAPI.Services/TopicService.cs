using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Data;
using WikiAPI.Models;
using WikiAPI.Models.Content;
using WikiAPI.Models.Subcontent;
using WikiAPI.Models.Topic;

namespace WikiAPI.Services
{
    public class TopicService
    {
        private readonly Guid _userId;
        public TopicService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTopic(TopicCreate topicmodel)
        {
            var entity =
                new Topic()
                {
                    TopicTitle = topicmodel.TopicTitle,
                    Summary = topicmodel.Summary,
                    TopicCreatedAt = DateTime.Now,
                    Author = _userId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Topics.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TopicListItem> GetTopic()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Topics
                    .Select(
                        e =>
                        new TopicListItem
                        {
                            TopicId = e.TopicId,
                            TopicTitle = e.TopicTitle,
                            Contents = e.Contents.Select(c => c.Title).ToList()
                        }
                        );
                return query.ToArray();
            }
        }
        public TopicDetail GetTopicById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Topics
                    .Single(e => e.TopicId == id);
                return
                    new TopicDetail()
                    {
                        TopicId = entity.TopicId,
                        TopicTitle = entity.TopicTitle,
                        Summary = entity.Summary,
                        TopicCreatedAt = entity.TopicCreatedAt,
                        Contents = entity.Contents.Select(x => new ContentDetail()
                        {
                            ContentId = x.ContentId,
                            Title = x.Title,
                            CreatedAt = x.CreatedAt,
                            Subcontents = x.Subcontents.Select(y => new SubcontentListItem()
                            {
                                Id = y.Id,
                                Title = y.Title,
                                Summary = y.Summary,

                            }).ToList()
                        }).ToList()
                    };
            }
        }
        public TopicDisplay GetArticle(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Topics
                    .Single(e => e.TopicId == id);
                return
                    new TopicDisplay()
                    {
                        TopicTitle = entity.TopicTitle,
                        Summary = entity.Summary,
                        Contents = entity.Contents.Select(x => new ContentDisplay()
                        {
                            Title = x.Title,
                            Subcontents = x.Subcontents.Select(y => new SubcontentDisplay()
                            {
                                Title = y.Title,
                                Summary = y.Summary,
                            }).ToList()
                        }).ToList()
                    };
            }
        }
        public bool UpdateTopic(TopicEdit topicmodel)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Topics
                    .Single(e => e.TopicId == topicmodel.TopicId);
                entity.TopicTitle = topicmodel.TopicTitle;
                entity.TopicCreatedAt = DateTime.Now;
                entity.Summary = topicmodel.Summary;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTopic(int topicId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Topics
                    .Single(e => e.TopicId == topicId);
                ctx.Topics.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
