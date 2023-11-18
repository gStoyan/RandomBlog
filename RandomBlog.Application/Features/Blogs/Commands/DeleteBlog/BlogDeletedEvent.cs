namespace RandomBlog.Application.Features.Blogs.Commands.DeleteBlog
{
    using RandomBlog.Domain.Common;
    using RandomBlog.Domain.Entities;

    public class BlogDeletedEvent : BaseEvent
    {
        public Blog blog { get; }

        public BlogDeletedEvent(Blog blog)
        {
            this.blog = blog;
        }
    }
}