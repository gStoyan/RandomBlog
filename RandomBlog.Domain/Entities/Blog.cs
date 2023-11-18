namespace RandomBlog.Domain.Entities
{
    using RandomBlog.Domain.Common;

    public class Blog : BaseAuditableEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string Attachment { get; set; }

        public string Picture { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
