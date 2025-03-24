using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Server.Data.Converters;
using Netmash.Shared.Mashes;

namespace Netmash.Server.Data.Configurations;

public class MashConfiguration : IEntityTypeConfiguration<Mash>
{
    public void Configure(EntityTypeBuilder<Mash> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .IsRequired();

        builder.Property(m => m.Name)
            .IsRequired();

        builder.HasMany(m => m.Blocks)
            .WithOne()
            .HasForeignKey("MashId");

        builder.Property(b => b.DivId);

        builder.Property(b => b.Styles)
            .HasConversion<StylesConverter>();
    }
}
