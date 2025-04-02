using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;

namespace Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;

internal static class DocumentsStatusesParametersByStatusTypeInternalConverter
{
    internal static DocumentsStatusesParametersByStatusTypeInternal FromDomain(KeyValuePair<DocumentStatusType, DocumentStatusParameter[]> parametersByStatusType)
    {
        DocumentStatusTypeInternal type = DocumentStatusTypeInternalConverter.FromDomain(parametersByStatusType.Key);

        DocumentStatusParameterInternal[] parameters = parametersByStatusType.Value.Select(DocumentStatusParameterInternalConverter.FromDomain).ToArray();

        var result = new DocumentsStatusesParametersByStatusTypeInternal(type, parameters);

        return result;
    }
}
