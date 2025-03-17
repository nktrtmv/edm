using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Queries;

internal static class GetDocumentsAllowedStatusesQueryBffConverter
{
    public static GetDocumentsAllowedStatusesQuery ToDto(GetDocumentsAllowedStatusesQueryBff query)
    {
        var result = new GetDocumentsAllowedStatusesQuery
        {
            DocumentsIds = { query.DocumentIds }
        };

        return result;
    }
}
