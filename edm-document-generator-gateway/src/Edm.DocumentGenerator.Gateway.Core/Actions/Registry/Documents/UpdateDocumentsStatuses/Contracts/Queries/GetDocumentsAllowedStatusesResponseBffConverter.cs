using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;

namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Queries;

internal static class GetDocumentsAllowedStatusesResponseBffConverter
{
    public static GetDocumentsAllowedStatusesResponseBff FromDto(GetDocumentsAllowedStatusesQueryResponse response)
    {
        DocumentStatusBff[] statuses = response.Statuses.Select(DocumentStatusBffConverter.ToBff).ToArray();

        var result = new GetDocumentsAllowedStatusesResponseBff(statuses);

        return result;
    }
}
