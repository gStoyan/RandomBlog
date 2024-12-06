namespace RandomBlog.Application.Features.Blogs.Commands.CreateBlog
{
    using MediatR;
    using RandomBlog.Application.Common.Mapping;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System;

    public record CreateBlogRequest : IRequest<Result<int>>, IMapFrom<Blog>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Attachment { get; set; }
        public string Picture { get; set; }
        public int UserId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
