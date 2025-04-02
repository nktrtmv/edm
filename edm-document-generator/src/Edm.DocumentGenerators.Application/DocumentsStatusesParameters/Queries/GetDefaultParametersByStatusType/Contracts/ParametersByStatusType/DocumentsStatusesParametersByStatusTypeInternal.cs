using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;

namespace Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;

public sealed class DocumentsStatusesParametersByStatusTypeInternal
{
    internal DocumentsStatusesParametersByStatusTypeInternal(DocumentStatusTypeInternal type, DocumentStatusParameterInternal[] parameters)
    {
        Type = type;
        Parameters = parameters;
    }

    public DocumentStatusTypeInternal Type { get; }
    public DocumentStatusParameterInternal[] Parameters { get; }
}
