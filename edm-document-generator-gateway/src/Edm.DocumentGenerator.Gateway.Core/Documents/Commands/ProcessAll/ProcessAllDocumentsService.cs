using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.ProcessAll.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.ProcessAll;

public sealed class ProcessAllDocumentsService(DocumentsService.DocumentsServiceClient documentsServiceClient)
{
    public async Task<ProcessAllDocumentsCommandBffResponse> ProcessAll(string domainId, CancellationToken cancellationToken)
    {
        var command = new ProcessAllDocumentsCommand { DomainId = domainId };

        await documentsServiceClient.ProcessAllAsync(command, cancellationToken: cancellationToken);

        var result = new ProcessAllDocumentsCommandBffResponse();

        return result;
    }
}
