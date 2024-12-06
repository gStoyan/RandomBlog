namespace RandomBlog.Application.Features.Blogs.Commands.CreateBlog
{
    using AutoMapper;
    using MediatR;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBlogHandler : IRequestHandler<CreateBlogRequest, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateBlogRequest command, CancellationToken cancellationToken)
        {
            var blog = new Blog()
            {
                Title = command.Title,
                Body = command.Body,
                Attachment = command.Attachment,
                Picture = command.Picture,
                UserId = command.UserId
            };

            await _unitOfWork.Repository<Blog>().AddAsync(blog);
            blog.AddDomainEvent(new BlogCreatedEvent(blog));

            await _unitOfWork.SaveAsync(cancellationToken);

            return await Result<int>.SuccessAsync(blog.Id, "Blog Created");
        }
    }
}
