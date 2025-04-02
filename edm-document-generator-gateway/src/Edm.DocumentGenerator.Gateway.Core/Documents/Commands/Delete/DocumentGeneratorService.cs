using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Delete;

public sealed class DocumentGeneratorService(DocumentsService.DocumentsServiceClient documentsServiceClient)
{
    public async Task DeleteDocumentByIds(string domainId, string[] ids, CancellationToken cancellationToken)
    {
        await documentsServiceClient.DeleteDocumentsAsync(
            new DeleteDocumentsCommand
            {
                DomainId = domainId,
                Ids = { ids }
            },
            cancellationToken: cancellationToken);
    }
}
