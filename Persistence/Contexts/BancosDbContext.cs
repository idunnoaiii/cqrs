using System.Reflection;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class BancosDbContext : DbContext
{

    private readonly IDatetimeService _datetimeService;
    
    public BancosDbContext(DbContextOptions<BancosDbContext> options, IDatetimeService datetimeService) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _datetimeService = datetimeService;
    }
    
    public DbSet<Client> Clients { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _datetimeService.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = _datetimeService.UtcNow;        
                    break;
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}