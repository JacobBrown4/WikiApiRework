using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiAPI.Data;
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
                    TopicCreatedAt = DateTime.Now,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Topic.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TopicListItem> GetTopic()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Topic.Where(e => e.AuthorId == _userId)
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




    }
}
