using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Server.Data.Converters;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class ImageBlockConfiguration : IEntityTypeConfiguration<ImageBlock>
{
    public void Configure(EntityTypeBuilder<ImageBlock> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .IsRequired();

        builder.Property(b => b.Url)
            .IsRequired();

        builder.Property(b => b.DivId);

        builder.Property(b => b.Styles)
            .HasConversion<StylesConverter>();
    }
}
