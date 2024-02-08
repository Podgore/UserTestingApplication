using Microsoft.EntityFrameworkCore;
using UserTestingApp.Entities;

namespace UserTestingApp.DAL.EF;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<TestTask> Tasks { get; set; } = null!;
    public DbSet<UserAnswer> UserAnswers { get; set; } = null!;
    public DbSet<Option> Options { get; set; } = null!;
    public DbSet<TestUser> TestUsers { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}