using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class ImageBlockConfiguration : IEntityTypeConfiguration<ImageBlock>
{
    public void Configure(EntityTypeBuilder<ImageBlock> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureStylable();
    }
}
