using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.MigrateAll.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.MigrateAll;

public sealed class MigrateAllDocumentsTemplatesService(DocumentTemplateService.DocumentTemplateServiceClient serviceClient)
    : DocumentTemplateServiceClientBase(serviceClient)
{
    public async Task<MigrateAllDocumentsTemplatesCommandBffResponse> MigrateAll(
        MigrateAllDocumentsTemplatesCommandBffCommand command,
        CancellationToken cancellationToken)
    {
        var rpcCommand = new MigrateAllDocumentsTemplatesCommand { DomainId = command.DomainId };

        await DocumentTemplateServiceClient.MigrateAllAsync(rpcCommand, cancellationToken: cancellationToken);

        return new MigrateAllDocumentsTemplatesCommandBffResponse();
    }
}
