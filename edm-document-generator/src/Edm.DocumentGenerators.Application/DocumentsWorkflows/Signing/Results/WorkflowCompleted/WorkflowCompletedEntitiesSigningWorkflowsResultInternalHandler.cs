using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Signing;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Results.WorkflowCompleted;

[UsedImplicitly]
internal sealed class WorkflowCompletedEntitiesSigningWorkflowsResultInternalHandler(
    DocumentsFacade documentsFacade,
    IRoleAdapter roleAdapter,
    ILogger<WorkflowCompletedEntitiesSigningWorkflowsResultInternalHandler> logger)
    : IRequestHandler<WorkflowCompletedEntitiesSigningWorkflowsResultInternal>
{
    public async Task Handle(WorkflowCompletedEntitiesSigningWorkflowsResultInternal request, CancellationToken cancellationToken)
    {
        Id<Document> documentId = IdConverterFrom<Document>.From(request.DocumentId);

        Document? document = await documentsFacade.GetRequired(documentId, cancellationToken);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        SigningWorkflowDocumentUpdate? update = WorkflowCompletedEntitiesSigningWorkflowsResultInternalConverter.ToDomain(request, currentUserId);

        DocumentUpdater.Update(roleAdapter, document, update);

        logger.LogInformation(
            """
            SIGNING WORKFLOW UPDATE: 📝📝📝 {Change:l}
            DocumentId: {DocumentId}
            SigningWorkflow: {Workflow}
            SigningStatus: {Status}
            """,
            update,
            documentId,
            request.WorkflowId,
            request.Status);

        await documentsFacade.Upsert(document, cancellationToken);
    }
}
