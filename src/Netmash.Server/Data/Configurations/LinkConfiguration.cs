using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Server.Data.Converters;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .IsRequired();

        builder.Property(b => b.SortOrder);

        builder.Property(l => l.Href);

        builder.Property(l => l.Title);

        builder.Property(l => l.Icon);

        builder.Property(b => b.DivId);

        builder.Property(b => b.Styles)
            .HasConversion<StylesConverter>();
    }
}
