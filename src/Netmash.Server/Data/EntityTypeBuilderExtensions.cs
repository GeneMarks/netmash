using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netmash.Server.Data.Converters;
using Netmash.Shared.Interfaces;

namespace Netmash.Server.Data;

public static class EntityTypeBuilderExtensions
{
    public static void ConfigureEntity<T>(this EntityTypeBuilder<T> builder)
        where T : class, IEntity
    {
        builder.HasKey(entity => entity.Id);
    }

    public static void ConfigureSortable<T>(this EntityTypeBuilder<T> builder)
        where T : class, ISortable
    {
        builder.Property(s => s.SortOrder);
    }

    public static void ConfigureStylable<T>(this EntityTypeBuilder<T> builder)
        where T : class, IStylable
    {
        builder.Property(stylable => stylable.Styles)
            .HasConversion<StylesConverter>();
    }
}
