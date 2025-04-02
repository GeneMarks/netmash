using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureSortable();
        builder.ConfigureStylable();
    }
}
