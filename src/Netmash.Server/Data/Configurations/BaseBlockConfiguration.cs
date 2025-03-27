using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class BaseBlockConfiguration : IEntityTypeConfiguration<BaseBlock>
{
    public void Configure(EntityTypeBuilder<BaseBlock> builder)
    {
        builder.ConfigureEntity();
        builder.ConfigureStylable();

        builder.HasDiscriminator<string>("BlockType")
            /*.HasValue<Text>("Text")*/
            .HasValue<ImageBlock>("Image")
            .HasValue<LinkGroupBlock>("LinkGroup")
            /*.HasValue<FileBrowser>("FileBrowser")*/
            /*.HasValue<Html>("Html")*/
            ;
    }
}
