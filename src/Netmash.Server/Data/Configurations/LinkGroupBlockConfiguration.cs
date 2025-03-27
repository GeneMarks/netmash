using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class LinkGroupBlockConfiguration : IEntityTypeConfiguration<LinkGroupBlock>
{
    public void Configure(EntityTypeBuilder<LinkGroupBlock> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureStylable();

        builder.HasMany(b => b.Links)
            .WithOne()
            .HasForeignKey("LinkGroupBlockId");
    }
}
