using TestTaskWersta.Models;
using Microsoft.EntityFrameworkCore;

namespace TestTaskWersta.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(o => o.OrderNumber).IsRequired().HasMaxLength(20);
            entity.HasIndex(o => o.OrderNumber).IsUnique();

            entity.Property(o => o.SenderCity).IsRequired().HasMaxLength(200);
            entity.Property(o => o.SenderAddress).IsRequired().HasMaxLength(500);
            entity.Property(o => o.RecipientCity).IsRequired().HasMaxLength(200);
            entity.Property(o => o.RecipientAddress).IsRequired().HasMaxLength(500);

            entity.Property(o => o.Weight).HasColumnType("numeric(10,2)");
        });
    }
}