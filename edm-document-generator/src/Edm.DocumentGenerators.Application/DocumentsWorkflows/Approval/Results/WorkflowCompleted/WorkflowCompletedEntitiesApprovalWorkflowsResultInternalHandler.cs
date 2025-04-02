using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted;

[UsedImplicitly]
internal sealed class WorkflowCompletedEntitiesApprovalWorkflowsResultInternalHandler(
    DocumentsFacade documentsFacade,
    IRoleAdapter roleAdapter,
    ILogger<WorkflowCompletedEntitiesApprovalWorkflowsResultInternalHandler> logger)
    : IRequestHandler<WorkflowCompletedEntitiesApprovalWorkflowsResultInternal>
{
    public async Task Handle(WorkflowCompletedEntitiesApprovalWorkflowsResultInternal request, CancellationToken cancellationToken)
    {
        Id<Document> documentId = IdConverterFrom<Document>.From(request.DocumentId);

        DomainId domainId = DomainId.Parse(request.DomainId);

        Document document;

        document = await documentsFacade.GetRequired(domainId, documentId, cancellationToken);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalWorkflowDocumentUpdate? update = WorkflowCompletedEntitiesApprovalWorkflowsResultInternalConverter.ToDomain(request, currentUserId);

        DocumentUpdater.Update(roleAdapter, document, update);

        logger.LogInformation(
            """
            APPROVAL WORKFLOW UPDATE: 📝📝📝 {Change:l}
            DocumentId: {DocumentId}
            WorkflowId: {WorkflowId:l},
            Status: {Status:l}
            """,
            update,
            documentId,
            request.WorkflowId,
            request.Status);

        await documentsFacade.Upsert(document, cancellationToken);
    }
}
