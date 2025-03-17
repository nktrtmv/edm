using System.Text.Json.Serialization;

namespace Edm.Document.Classifier.Infrastructure.Repositories.Domains.Contracts;

[JsonDerivedType(typeof(UnvalidatedReferenceMarkAttributeWithRoleCondition), "Reference")]
[JsonDerivedType(typeof(UnvalidatedStringMarkAttributeWithRoleCondition), "String")]
[JsonDerivedType(typeof(UnvalidatedNumberMarkAttributeWithRoleCondition), "Number")]
[JsonDerivedType(typeof(UnvalidatedAttachmentMarkAttributeWithRoleCondition), "Attachment")]
[JsonDerivedType(typeof(UnvalidatedDateMarkAttributeWithRoleCondition), "Date")]
[JsonDerivedType(typeof(UnvalidatedBooleanMarkAttributeWithRoleCondition), "Boolean")]
public abstract record UnvalidatedMarkAttributeWithRoleCondition;

public sealed record UnvalidatedReferenceMarkAttributeWithRoleCondition(int ReferenceId) : UnvalidatedMarkAttributeWithRoleCondition;

public sealed record UnvalidatedStringMarkAttributeWithRoleCondition : UnvalidatedMarkAttributeWithRoleCondition;

public sealed record UnvalidatedNumberMarkAttributeWithRoleCondition : UnvalidatedMarkAttributeWithRoleCondition;

public sealed record UnvalidatedDateMarkAttributeWithRoleCondition : UnvalidatedMarkAttributeWithRoleCondition;

public sealed record UnvalidatedAttachmentMarkAttributeWithRoleCondition : UnvalidatedMarkAttributeWithRoleCondition;

public sealed record UnvalidatedBooleanMarkAttributeWithRoleCondition : UnvalidatedMarkAttributeWithRoleCondition;
