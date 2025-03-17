using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentStatusParameters;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsStatusesParameters.Relations.ByStatusType;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsStatusesParameters;

public sealed class DocumentsStatusesParametersRepository : IDocumentsStatusesParametersRepository
{
    Task<Dictionary<DocumentStatusType, DocumentStatusParameter[]>> IDocumentsStatusesParametersRepository.GetParametersByStatusType(CancellationToken cancellationToken)
    {
        Dictionary<DocumentStatusType, DocumentStatusParameter[]> result = DocumentsStatusesParametersByStatusTypeProvider.ParametersByStatusType;

        return Task.FromResult(result);
    }
}
