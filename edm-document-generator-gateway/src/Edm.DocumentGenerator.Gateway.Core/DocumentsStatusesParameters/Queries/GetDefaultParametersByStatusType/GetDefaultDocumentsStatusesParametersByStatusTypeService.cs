using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType;

public sealed class GetDefaultDocumentsStatusesParametersByStatusTypeService : DocumentsStatusesParametersServiceClientBase
{
    public GetDefaultDocumentsStatusesParametersByStatusTypeService(DocumentsStatusesParametersService.DocumentsStatusesParametersServiceClient serviceClient)
        : base(serviceClient)
    {
    }

    public async Task<GetDefaultDocumentsStatusesParametersByStatusTypeQueryBffResponse> Get(CancellationToken cancellationToken)
    {
        var query = new GetDefaultDocumentsStatusesParametersByStatusTypeQuery();

        var response =
            await ServiceClient.GetDefaultParametersByStatusTypeAsync(query, cancellationToken: cancellationToken);

        DocumentsStatusesParametersByStatusTypeBff[] parametersByStatusType =
            response.ParametersByStatusType.Select(DocumentsStatusesParametersByStatusTypeBffConverter.FromDto).ToArray();

        var result = new GetDefaultDocumentsStatusesParametersByStatusTypeQueryBffResponse
        {
            ParametersByStatusType = CollectionQueryResponseConverter.ToBff(parametersByStatusType)
        };

        return result;
    }
}
