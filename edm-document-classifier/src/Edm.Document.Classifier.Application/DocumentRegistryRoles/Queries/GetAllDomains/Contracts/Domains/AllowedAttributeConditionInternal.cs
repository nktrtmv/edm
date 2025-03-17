﻿using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains;

public abstract record AllowedAttributeConditionInternal;

public sealed record AttachmentAllowedAttributeConditionInternal : AllowedAttributeConditionInternal;

public sealed record DateAllowedAttributeConditionInternal : AllowedAttributeConditionInternal;

public sealed record ReferenceAllowedAttributeConditionInternal(DocumentReferenceTypeId ReferenceId) : AllowedAttributeConditionInternal;

public sealed record StringAllowedAttributeConditionInternal : AllowedAttributeConditionInternal;

public sealed record NumberAllowedAttributeConditionInternal : AllowedAttributeConditionInternal;

public sealed record BooleanAllowedAttributeConditionInternal : AllowedAttributeConditionInternal;
