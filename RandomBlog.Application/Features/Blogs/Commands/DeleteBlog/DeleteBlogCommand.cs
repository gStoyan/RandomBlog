namespace RandomBlog.Application.Features.Blogs.Commands.DeleteBlog
{
    using AutoMapper;
    using MediatR;
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Threading;
    using System.Threading.Tasks;

    public record DeleteBlogCommand : IRequest<Result<int>>, IMapFrom<Blog>
    {
        public int Id { get; set; }

        public DeleteBlogCommand()
        {

        }

        public DeleteBlogCommand(int id)
        {
            Id = id;
        }
    }

    internal class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Result<int>>
    {
        private readonly IUnitOfWork _uniUnitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uniUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteBlogCommand command, CancellationToken cancellationToken)
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
