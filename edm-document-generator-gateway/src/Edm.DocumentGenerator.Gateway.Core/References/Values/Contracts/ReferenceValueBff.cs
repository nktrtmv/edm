using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

[DebuggerDisplay("{ToDebugDisplay}")]
public sealed class ReferenceValueBff
{
    public required string Id { get; init; }
    public required string DisplayValue { get; set; }
    public required string DisplaySubValue { get; set; }
    public required bool IsHidden { get; set; }
    public required string ConcurrencyToken { get; set; }

    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
