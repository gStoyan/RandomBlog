namespace RandomBlog.Application.Features.Blogs.Commands.Queries.GetAllBlogs
{
    using MediatR;
    using RandomBlog.Shared;

    public record GetAllBlogsRequest : IRequest<Result<List<GetAllBlogsDto>>>;
}
