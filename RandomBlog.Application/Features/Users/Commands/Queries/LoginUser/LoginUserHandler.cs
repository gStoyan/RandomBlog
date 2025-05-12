namespace RandomBlog.Application.Features.Users.Commands.Queries.LoginUser
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using RandomBlog.Application.Features.Users.Commands.Queries.GetUser;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Threading;
    using System.Threading.Tasks;

    internal class LoginUserHandler : IRequestHandler<LoginUserRequest, Result<LoginUserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<LoginUserDto>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<User>().Entities.ProjectTo<LoginUserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password, cancellationToken);

            if (user == null)
                return await Result<LoginUserDto>.FailureAsync("Invalid Email or Password");

            return await Result<LoginUserDto>.SuccessAsync(user, "Login Successful");
        }
    }
}
