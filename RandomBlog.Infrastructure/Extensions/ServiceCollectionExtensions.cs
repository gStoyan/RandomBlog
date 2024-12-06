namespace RandomBlog.Infrastructure.Extensions
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Common;
    using RandomBlog.Domain.Common.Interfaces;
    using RandomBlog.Infrastructure.Repositories;

    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RandomBlogDbContext>(options =>
            options.UseSqlServer(connectionString,
            builder => builder.MigrationsAssembly(typeof(RandomBlogDbContext).Assembly.FullName)));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IBlogRepository, BlogRepository>();
        }
    }
}
