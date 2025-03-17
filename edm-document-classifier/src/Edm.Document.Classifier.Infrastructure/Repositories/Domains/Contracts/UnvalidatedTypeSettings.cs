using System.Text.Json.Serialization;

using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

[JsonDerivedType(typeof(UnvalidatedStringTypeSettings), "String")]
[JsonDerivedType(typeof(UnvalidatedNumberTypeSettings), "Number")]
[JsonDerivedType(typeof(UnvalidatedDateTypeSettings), "Date")]
[JsonDerivedType(typeof(UnvalidatedReferenceTypeSettings), "Reference")]
[JsonDerivedType(typeof(UnvalidatedAttachmentTypeSettings), "Attachment")]
[JsonDerivedType(typeof(UnvalidatedBooleanTypeSettings), "Boolean")]
public abstract record UnvalidatedTypeSettings;

public sealed record UnvalidatedStringTypeSettings : UnvalidatedTypeSettings;

public sealed record UnvalidatedBooleanTypeSettings : UnvalidatedTypeSettings;

public sealed record UnvalidatedNumberTypeSettings(int Precision) : UnvalidatedTypeSettings;

public sealed record UnvalidatedDateTypeSettings(DateRegistryRoleDisplayType DisplayType) : UnvalidatedTypeSettings;

public sealed record UnvalidatedReferenceTypeSettings(int ReferenceId, ReferenceRegistryRoleDisplayType DisplayType) : UnvalidatedTypeSettings;

public sealed record UnvalidatedAttachmentTypeSettings : UnvalidatedTypeSettings;
