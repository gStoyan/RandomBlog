namespace RandomBlog.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using RandomBlog.Domain.Common;
    using RandomBlog.Domain.Common.Interfaces;
    using RandomBlog.Domain.Entities;
    using System.Reflection;

    public class RandomBlogDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public RandomBlogDbContext(DbContextOptions<RandomBlogDbContext> options, IDomainEventDispatcher dispatcher)
        : base(options)
        {
            _dispatcher = dispatcher;
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Blog>()
                .HasOne<User>(b => b.User)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.UserId);
            builder.Entity<User>()
                .HasMany<Blog>(u => u.Blogs)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
