using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.Contracts;

internal static class UpdateDocumentsResponseBffConverter
{
    public static UpdateDocumentsResponseBff FromDto(DocumentClerkBatchUpdateCommandResponse response)
    {
        var result = new UpdateDocumentsResponseBff(response.UncompletedDocumentIds.ToArray());

        return result;
    }

    public static UpdateDocumentsResponseBff FromDto(DocumentStatusBatchUpdateCommandResponse response)
    {
        var result = new UpdateDocumentsResponseBff(response.UncompletedDocumentIds.ToArray());

        return result;
    }
}
