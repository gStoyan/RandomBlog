namespace RandomBlog.Application.Features.Users.Commands.Queries.GetAllUsers
{
    using MediatR;
    using RandomBlog.Shared;

    internal class GetAllUsersRequest : IRequest<Result<List<GetAllUsersDto>>>
    {
    }
}
