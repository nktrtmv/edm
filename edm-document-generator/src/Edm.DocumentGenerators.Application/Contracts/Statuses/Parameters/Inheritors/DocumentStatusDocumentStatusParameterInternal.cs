using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;

public sealed record DocumentStatusDocumentStatusParameterInternal(
    DocumentStatusParameterKind Kind,
    Id<DocumentStatusInternal>? Value) : DocumentStatusParameterInternal(Kind);
