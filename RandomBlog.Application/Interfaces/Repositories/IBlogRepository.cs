namespace RandomBlog.Application.Interfaces.Repositories
{
    using RandomBlog.Domain.Entities;

    public interface IBlogRepository
    {
        Task<List<Blog>> GetBlogsByUser(int userId);
    }
}
