namespace RandomBlog.Application.Features.Users.Commands.CreateUser
{
    using MediatR;
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.ComponentModel.DataAnnotations;

    public record CreateUserRequest : IRequest<Result<int>>, IMapFrom<User>
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ProfilePicture { get; set; }

    }
}
