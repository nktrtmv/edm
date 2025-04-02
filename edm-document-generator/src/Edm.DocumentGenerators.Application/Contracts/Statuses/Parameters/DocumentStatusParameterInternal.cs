using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;

public abstract record DocumentStatusParameterInternal(DocumentStatusParameterKind Kind);
