namespace RandomBlog.Application.Features.Users.Commands.Queries.GetAllUsers
{
    using MediatR;
    using RandomBlog.Shared;

    public record GetAllUsersRequest : IRequest<Result<List<GetAllUsersDto>>>
    {
    }
}
