namespace RandomBlog.Application.Features.Blogs.Commands.CreateBlog
{
    using RandomBlog.Domain.Common;
    using RandomBlog.Domain.Entities;

    public class BlogCreatedEvent : BaseEvent
    {
        public Blog blog { get; }

        public BlogCreatedEvent(Blog blog)
        {
            this.blog = blog;
        }
    }
}