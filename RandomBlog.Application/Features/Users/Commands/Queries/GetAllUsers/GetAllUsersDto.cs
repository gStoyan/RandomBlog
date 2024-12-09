namespace RandomBlog.Application.Features.Users.Commands.Queries.GetAllUsers
{
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Domain.Entities;

    internal class GetAllUsersDto : IMapFrom<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProfilePicture { get; set; }
    }
}