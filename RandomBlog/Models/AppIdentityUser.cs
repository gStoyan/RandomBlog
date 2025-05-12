namespace RandomBlog.WebAPI.Models
{
    using Microsoft.AspNetCore.Identity;
    using RandomBlog.Domain.Entities;

    public class AppIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }

        public User ToDomainUser()
        {
            return new User()
            {
                Name = this.Name,
                Password = this.Password,
                Email = this.Email,
                ProfilePricture = this.ProfilePicture,
            };
        }
    }
}
