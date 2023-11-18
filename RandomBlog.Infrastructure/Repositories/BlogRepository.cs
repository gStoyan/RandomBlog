namespace RandomBlog.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BlogRepository : IBlogRepository
    {
        private readonly IGenericRepository<Blog> _repository;

        public BlogRepository(IGenericRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<Blog>> GetBlogsByUser(int userId) => await _repository.Entities.Where(x => x.UserId == userId).ToListAsync();
    }
}
