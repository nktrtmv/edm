using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;

public sealed record StringDocumentStatusParameterInternal(DocumentStatusParameterKind Kind, string Value) : DocumentStatusParameterInternal(Kind);
