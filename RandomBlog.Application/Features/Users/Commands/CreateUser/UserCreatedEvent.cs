namespace RandomBlog.Application.Features.Users.Commands.CreateUser
{
    using RandomBlog.Domain.Common;
    using RandomBlog.Domain.Entities;

    internal class UserCreatedEvent : BaseEvent
    {
        public User User { get; }

        public UserCreatedEvent(User user)
        {
            User = user;
        }
    }
}
