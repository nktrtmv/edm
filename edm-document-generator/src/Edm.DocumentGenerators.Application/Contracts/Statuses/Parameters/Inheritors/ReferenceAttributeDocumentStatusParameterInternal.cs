using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;

public sealed record ReferenceAttributeDocumentStatusParameterInternal(
    DocumentStatusParameterKind Kind,
    Metadata<ReferenceAttributeDocumentStatusParameterInternal> ReferenceType,
    Id<DocumentAttributeInternal>[] Values,
    bool IsArray) : DocumentStatusParameterInternal(Kind);
