using Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts;

public sealed class GetDefaultDocumentsStatusesParametersByStatusTypeQueryBffResponse
{
    public required CollectionQueryResponse<DocumentsStatusesParametersByStatusTypeBff> ParametersByStatusType { get; init; }
}
