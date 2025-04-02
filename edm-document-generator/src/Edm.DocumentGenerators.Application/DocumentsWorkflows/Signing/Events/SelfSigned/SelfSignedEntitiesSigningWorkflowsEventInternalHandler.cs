using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Events.SelfSigned.Contracts;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.SigningData;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Events.SelfSigned;

[UsedImplicitly]
internal sealed class SelfSignedEntitiesSigningWorkflowsEventInternalHandler : IRequestHandler<SelfSignedEntitiesSigningWorkflowsEventInternal>
{
    public SelfSignedEntitiesSigningWorkflowsEventInternalHandler(DocumentsFacade documents)
    {
        Documents = documents;
    }

    private DocumentsFacade Documents { get; }

    public async Task Handle(SelfSignedEntitiesSigningWorkflowsEventInternal request, CancellationToken cancellationToken)
    {
        Id<Document>? documentId = IdConverterFrom<Document>.From(request.DocumentId);

        Document? document = await Documents.GetRequired(documentId, cancellationToken);

        Id<DocumentSigningWorkflow>? workflowId = IdConverterFrom<DocumentSigningWorkflow>.From(request.WorkflowId);

        bool isUpdated = DocumentSigningDataUpdater.TryUpdateSelfSigned(document, workflowId);

        if (isUpdated)
        {
            await Documents.Upsert(document, cancellationToken);
        }
    }
}
