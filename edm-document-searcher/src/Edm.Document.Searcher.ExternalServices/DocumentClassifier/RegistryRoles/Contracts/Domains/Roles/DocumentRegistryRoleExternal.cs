using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;

using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles;

[DebuggerDisplay("{ToDebugDisplay}")]
public sealed record DocumentRegistryRoleExternal(
    int Id,
    string DisplayName,
    DocumentRegistryRoleTypeExternal Type,
    int Kind,
    string SystemName)
{
    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
