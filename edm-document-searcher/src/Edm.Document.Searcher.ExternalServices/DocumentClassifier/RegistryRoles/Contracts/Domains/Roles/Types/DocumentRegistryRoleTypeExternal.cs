using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Booleans;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Dates;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Numbers;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.References;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types.Inheritors.Strings;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types;

[JsonDerivedType(typeof(DocumentBooleanRegistryRoleTypeExternal))]
[JsonDerivedType(typeof(DocumentStringRegistryRoleTypeExternal))]
[JsonDerivedType(typeof(DocumentNumberRegistryRoleTypeExternal))]
[JsonDerivedType(typeof(DocumentReferenceRegistryRoleTypeExternal))]
[JsonDerivedType(typeof(DocumentDateRegistryRoleTypeExternal))]
[DebuggerDisplay("{ToDebugDisplay}")]
public abstract class DocumentRegistryRoleTypeExternal
{
    private string ToDebugDisplay => JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
}
