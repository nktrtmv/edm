using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.MigrateAll.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.MigrateAll;

[UsedImplicitly]
internal sealed class MigrateAllDocumentsTemplatesCommandInternalHandler(DocumentsTemplatesFacade templates)
    : IRequestHandler<MigrateAllDocumentsTemplatesCommandInternal>
{
    public async Task Handle(MigrateAllDocumentsTemplatesCommandInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        await templates.MigrateAll(domainId, cancellationToken);
    }
}
