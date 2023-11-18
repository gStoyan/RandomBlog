namespace RandomBlog.Domain.Common.Interfaces
{
    using System;

    public interface IAuditableEntity : IEntity
    {
        int? CreatedBy { get; set; }
        DateTime? Created { get; set; }
        DateTime? LastModified { get; set; }
        int? ModifiedBy { get; set; }
    }
}
