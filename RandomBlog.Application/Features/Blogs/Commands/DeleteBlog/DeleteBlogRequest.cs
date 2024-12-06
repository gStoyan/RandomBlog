namespace RandomBlog.Application.Features.Blogs.Commands.DeleteBlog
{
    using MediatR;
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;

    public record DeleteBlogRequest : IRequest<Result<int>>, IMapFrom<Blog>
    {
        public int Id { get; set; }

        public DeleteBlogRequest()
        {

        }

        public DeleteBlogRequest(int id)
        {
            Id = id;
        }
    }
}
