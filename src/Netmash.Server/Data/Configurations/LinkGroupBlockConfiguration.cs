using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Server.Data.Converters;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class LinkGroupBlockConfiguration : IEntityTypeConfiguration<LinkGroupBlock>
{
    public void Configure(EntityTypeBuilder<LinkGroupBlock> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .IsRequired();

        builder.HasMany(b => b.Links)
            .WithOne()
            .HasForeignKey("LinkGroupBlockId");

        builder.Property(b => b.DivId);

        builder.Property(b => b.Styles)
            .HasConversion<StylesConverter>();
    }
}
