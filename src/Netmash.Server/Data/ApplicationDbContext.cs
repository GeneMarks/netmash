using Microsoft.EntityFrameworkCore;
using Netmash.Shared.Blocks;
using Netmash.Shared.Mashes;

namespace Netmash.Server.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Mash> Mashes { get; set; }
    public DbSet<BaseBlock> Blocks { get; set; }
    public DbSet<Link> Links { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
