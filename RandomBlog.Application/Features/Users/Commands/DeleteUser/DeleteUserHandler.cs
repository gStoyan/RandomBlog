namespace RandomBlog.Application.Features.Users.Commands.DeleteUser
{
    using MediatR;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Threading;
    using System.Threading.Tasks;

    internal class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.Repository<User>().Entities.FirstOrDefault(x => x.Id == request.Id);

            if (user != null)
            {
                await _unitOfWork.Repository<User>().DeleteAsync(user);
                user.AddDomainEvent(new UserDeletedEvent(user));

                await _unitOfWork.SaveAsync(cancellationToken);

                return await Result<int>.SuccessAsync(user.Id, "User Deleted");
            }

            return await Result<int>.FailureAsync("User not found");
        }
    }
}
