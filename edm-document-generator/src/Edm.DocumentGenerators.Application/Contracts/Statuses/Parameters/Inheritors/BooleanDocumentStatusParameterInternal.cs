using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;

public sealed record BooleanDocumentStatusParameterInternal(DocumentStatusParameterKind Kind, bool Value) : DocumentStatusParameterInternal(Kind);
