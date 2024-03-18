using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker
            .Entries<BaseEntity>();
        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreateTime = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().ToTable("Todos").HasData(new Todo
        {
            Id = Guid.NewGuid(),
            Title = "First Todo",
            Content = "This is the first todo",
            CreateTime = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            Status = TodoStatus.InProgress
        },
            new Todo
            {
                Id = Guid.NewGuid(),
                Title = "Second Todo",
                Content = "This is the second todo",
                CreateTime = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Status = TodoStatus.Waiting
            });
        modelBuilder.Entity<User>().ToTable("Users").HasData(new User
        {
            Id = Guid.NewGuid(),
            Email = "user@example.com",
            FirstName = "Can",
            LastName = "Doe",
            CreateTime = DateTime.UtcNow,
            Password = "D0B3749570B6AA9155E3CAF5E42D9AEFE826600AF86A80EE4051CE6F76FA5D0D:2A59480760E144B6C0BC4954D3C2B37B:50000:SHA256",
            UpdatedDate = DateTime.UtcNow
        });
    }
}