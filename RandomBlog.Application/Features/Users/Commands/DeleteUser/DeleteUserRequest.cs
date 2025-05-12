namespace RandomBlog.Application.Features.Users.Commands.DeleteUser
{
    using MediatR;
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;

    public record DeleteUserRequest : IRequest<Result<int>>, IMapFrom<User>
    {
        public int Id { get; init; }
        public DeleteUserRequest()
        {

        }

        public DeleteUserRequest(int id)
        {
            Id = id;
        }
    }
}
