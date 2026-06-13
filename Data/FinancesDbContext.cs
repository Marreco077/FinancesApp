using Finances.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finances.Data;

public class FinancesDbContext : DbContext
{
    public FinancesDbContext(DbContextOptions<FinancesDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancesDbContext).Assembly);
    }
}