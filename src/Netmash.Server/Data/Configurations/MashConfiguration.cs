using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Shared.Mashes;

namespace Netmash.Server.Data.Configurations;

public class MashConfiguration : IEntityTypeConfiguration<Mash>
{
    public void Configure(EntityTypeBuilder<Mash> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureStylable();

        builder.Property(m => m.Name)
            .IsRequired();

        builder.HasMany(m => m.Blocks)
            .WithOne()
            .HasForeignKey("MashId");
    }
}
