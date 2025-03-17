using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Kinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles.Types;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

[DebuggerDisplay("{ToDebugDisplay}")]
public sealed record DocumentRegistryRoleExternal(
    int Id,
    string Name,
    string DisplayName,
    string SystemName,
    FilterSettingsExternal FilterSettings,
    RegistrySettingsExternal RegistrySettings,
    DocumentRegistryRoleTypeExternal Type,
    DocumentRegistryRoleKindExternal Kind)
{
    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
