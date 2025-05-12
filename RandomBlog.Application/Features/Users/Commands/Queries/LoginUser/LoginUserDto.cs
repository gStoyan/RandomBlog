namespace RandomBlog.Application.Features.Users.Commands.Queries.LoginUser
{
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Domain.Entities;

    internal class LoginUserDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
