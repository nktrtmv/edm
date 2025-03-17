using Edm.DocumentGenerators.Application.Documents.Commands.ProcessAll.Contracts;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.ProcessAll;

[UsedImplicitly]
internal sealed class ProcessAllDocumentsCommandInternalHandler : IRequestHandler<ProcessAllDocumentsCommandInternal>
{
    public ProcessAllDocumentsCommandInternalHandler(DocumentsFacade documents)
    {
        Documents = documents;
    }

    private DocumentsFacade Documents { get; }

    public async Task Handle(ProcessAllDocumentsCommandInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        await Documents.ProcessAll(domainId, cancellationToken);
    }
}
