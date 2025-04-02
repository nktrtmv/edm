using Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsStatusesParameters.Converters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsStatusesParameters.Converters.Queries.GetDefaultParametersByStatusType;

internal static class GetDefaultDocumentsStatusesParametersByStatusTypeQueryResponseConverter
{
    internal static GetDefaultDocumentsStatusesParametersByStatusTypeQueryResponse FromInternal(
        GetDefaultDocumentsStatusesParametersByStatusTypeQueryInternalResponse response)
    {
        DocumentsStatusesParametersByStatusTypeDto[] parametersByStatusType =
            response.ParametersByStatusType.Select(DocumentsStatusesParametersByStatusTypeDtoConverter.FromInternal).ToArray();

        var result = new GetDefaultDocumentsStatusesParametersByStatusTypeQueryResponse
        {
            ParametersByStatusType = { parametersByStatusType }
        };

        return result;
    }
}
