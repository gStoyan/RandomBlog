namespace RandomBlog.Domain.Common
{
    using RandomBlog.Domain.Common.Interfaces;
    using System;

    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
