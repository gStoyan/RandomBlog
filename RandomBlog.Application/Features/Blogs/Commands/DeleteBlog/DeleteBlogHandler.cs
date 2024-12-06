namespace RandomBlog.Application.Features.Blogs.Commands.DeleteBlog
{
    using AutoMapper;
    using MediatR;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Threading;
    using System.Threading.Tasks;



    internal class DeleteBlogHandler : IRequestHandler<DeleteBlogRequest, Result<int>>
    {
        private readonly IUnitOfWork _uniUnitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uniUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteBlogRequest command, CancellationToken cancellationToken)
        {
            var blog = await _uniUnitOfWork.Repository<Blog>().GetByIdAsync(command.Id);
            if (blog != null)
            {
                await _uniUnitOfWork.Repository<Blog>().DeleteAsync(blog);
                blog.AddDomainEvent(new BlogDeletedEvent(blog));

                await _uniUnitOfWork.SaveAsync(cancellationToken);

                return await Result<int>.SuccessAsync(blog.Id, "Blog Deleted");
            }

            return await Result<int>.FailureAsync("Blog not found");
        }
    }
}
