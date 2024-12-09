namespace RandomBlog.Application.Features.Users.Commands.DeleteUser
{
    using RandomBlog.Domain.Common;
    using RandomBlog.Domain.Entities;

    internal class UserDeletedEvent : BaseEvent
    {
        public User User { get; set; }

        public UserDeletedEvent(User user)
        {
            this.User = user;
        }
    }
}
