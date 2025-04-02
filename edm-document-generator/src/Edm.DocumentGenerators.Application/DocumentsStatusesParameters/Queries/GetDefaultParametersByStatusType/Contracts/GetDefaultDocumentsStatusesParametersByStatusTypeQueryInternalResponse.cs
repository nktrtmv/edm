using Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;

namespace Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts;

public sealed class GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternalResponse
{
    internal GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternalResponse(DocumentsStatusesParametersByStatusTypeInternal[] parametersByStatusType)
    {
        ParametersByStatusType = parametersByStatusType;
    }

    public DocumentsStatusesParametersByStatusTypeInternal[] ParametersByStatusType { get; }
}
