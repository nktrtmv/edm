using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;

public sealed record IntegrationStageDocumentStatusParameter(DocumentStatusParameterKind Kind) : DocumentStatusParameter(Kind);
