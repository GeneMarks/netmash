using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Server.Data.Converters;
using Netmash.Shared.Blocks;

namespace Netmash.Server.Data.Configurations;

public class BaseBlockConfiguration : IEntityTypeConfiguration<BaseBlock>
{
    public void Configure(EntityTypeBuilder<BaseBlock> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .IsRequired();

        builder.Property(b => b.SortOrder);

        builder.HasDiscriminator<string>("BlockType")
            /*.HasValue<Text>("Text")*/
            .HasValue<ImageBlock>("Image")
            .HasValue<LinkGroupBlock>("LinkGroup");
            /*.HasValue<FileBrowser>("FileBrowser")*/
            /*.HasValue<Html>("Html");*/

        builder.Property(b => b.DivId);

        builder.Property(b => b.Styles)
            .HasConversion<StylesConverter>();
    }
}
