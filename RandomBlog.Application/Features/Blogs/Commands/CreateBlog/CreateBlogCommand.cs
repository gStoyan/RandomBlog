namespace RandomBlog.Application.Features.Blogs.Commands.CreateBlog
{
    using AutoMapper;
    using MediatR;
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Threading;
    using System.Threading.Tasks;

    public record CreateBlogCommand : IRequest<Result<int>>, IMapFrom<Blog>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Attachment { get; set; }
        public string Picture { get; set; }
        public int UserId { get; set; }
    }

    internal class CreateBlogCommandHangler : IRequestHandler<CreateBlogCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogCommandHangler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
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
