namespace RandomBlog.Application.Features.Users.Commands.CreateUser
{
    using AutoMapper;
    using MediatR;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CreateUserHandler : IRequestHandler<CreateUserRequest, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Result<int>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Blogs = new List<Blog>(),
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                ProfilePricture = "default.jpg"
            };

            await _unitOfWork.Repository<User>().AddAsync(user);
            user.AddDomainEvent(new UserCreatedEvent(user));

            await _unitOfWork.SaveAsync(cancellationToken);

            return await Result<int>.SuccessAsync(user.Id, "User Created");
        }
    }
}
