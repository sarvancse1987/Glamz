using Glamz.Business.Common.Interfaces.Seo;
using Glamz.Infrastructure.Events;
using Glamz.Domain.Blogs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.Cms.Interfaces.Events
{
    public class BlogPostDeletedEventHandler : INotificationHandler<EntityDeleted<BlogPost>>
    {
        private readonly ISlugService _slugService;

        public BlogPostDeletedEventHandler(ISlugService slugService)
        {
            _slugService = slugService;
        }
        public async Task Handle(EntityDeleted<BlogPost> notification, CancellationToken cancellationToken)
        {
            var urlToDelete = await _slugService.GetBySlug(notification.Entity.SeName);
            await _slugService.DeleteEntityUrl(urlToDelete);
        }
    }
}
