using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Data;
using WikiAPI.Models.Content;
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
                    TopicId = topicmodel.TopicId,
                    TopicTitle = topicmodel.TopicTitle,
                    Summary = topicmodel.Summary,
                    TopicCreatedAt = DateTime.Now
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
                    .Topics.Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new TopicListItem
                        {
                            TopicId = e.TopicId,
                            TopicTitle = e.TopicTitle,
                            TopicCreatedAt = e.TopicCreatedAt
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
                    .Single(e => e.TopicId == id && e.AuthorId == _userId);
                return
                    new TopicDetail()
                    {
                        TopicId = entity.TopicId,
                        TopicTitle = entity.TopicTitle,
                        Summary = entity.Summary,
                        TopicCreatedAt = entity.TopicCreatedAt,
                        Contents = entity.Contents.Select(x => new ContentListItem()
                        {
                            ContentId = x.ContentId,
                            Title = x.Title
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
