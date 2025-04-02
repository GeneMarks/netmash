using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class BaseBlockConfiguration : IEntityTypeConfiguration<BaseBlock>
{
    public void Configure(EntityTypeBuilder<BaseBlock> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureSortable();
        builder.ConfigureStylable();

        builder.HasDiscriminator(b => b.BlockType)
            /*.HasValue<Text>("Text")*/
            .HasValue<ImageBlock>(BlockType.Image)
            .HasValue<LinkGroupBlock>(BlockType.LinkGroup)
            /*.HasValue<FileBrowser>("FileBrowser")*/
            /*.HasValue<Html>("Html")*/
            ;
    }
}
