using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

[DebuggerDisplay("{ToDebugDisplay}")]
public sealed class ReferenceTypeValueBff
{
    public required string Id { get; init; }
    public required string DisplayValue { get; set; }
    public required string DisplaySubValue { get; set; }
    public Dictionary<string, string> Arguments { get; set; } = [];

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });

    internal void Enrich(ReferenceTypeValueBff other)
    {
        DisplayValue = other.DisplayValue;
        DisplaySubValue = other.DisplaySubValue;
    }

    public static ReferenceTypeValueBff CreateNotEnriched(string id)
    {
        var result = new ReferenceTypeValueBff
        {
            Id = id,
            DisplayValue = string.Empty,
            DisplaySubValue = string.Empty
        };

        return result;
    }
}
