using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Netmash.Shared.Styling;

namespace Netmash.Server.Data.Converters;

public class StylesConverter : ValueConverter<HashSet<Style>, string>
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new();
    public StylesConverter() : base(
        styles => JsonSerializer.Serialize(styles, _jsonSerializerOptions),
        json => JsonSerializer.Deserialize<HashSet<Style>>(json, _jsonSerializerOptions) ?? new HashSet<Style>()) { }
}
