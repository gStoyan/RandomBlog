namespace RandomBlog.Domain.Entities
{
    using RandomBlog.Domain.Common;

    public class User : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePricture { get; set; }
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
