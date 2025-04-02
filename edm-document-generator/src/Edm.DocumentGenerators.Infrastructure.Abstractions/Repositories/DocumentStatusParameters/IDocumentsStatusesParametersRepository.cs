using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;

namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentStatusParameters;

public interface IDocumentsStatusesParametersRepository
{
    Task<Dictionary<DocumentStatusType, DocumentStatusParameter[]>> GetParametersByStatusType(CancellationToken cancellationToken);
}
