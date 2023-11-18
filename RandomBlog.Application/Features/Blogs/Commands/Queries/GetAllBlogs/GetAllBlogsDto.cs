namespace RandomBlog.Application.Features.Blogs.Commands.Queries.GetAllBlogs
{
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Domain.Entities;

    public class GetAllBlogsDto : IMapFrom<Blog>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Attachment { get; set; }
        public string Picture { get; set; }
        public int UserId { get; set; }
    }
}
