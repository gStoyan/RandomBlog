namespace RandomBlog.Application.Features.Users.Commands.Queries.GetUser
{
    using MediatR;
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Application.Features.Users.Commands.Queries.LoginUser;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;

    public record LoginUserRequest : IRequest<Result<LoginUserDto>>, IMapFrom<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
