using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts;

public sealed record WorkflowCompletedEntitiesApprovalWorkflowsResultInternal(
    string DomainId,
    Id<DocumentInternal> DocumentId,
    Id<DocumentApprovalWorkflowInternal> WorkflowId,
    DocumentApprovalStatusInternal Status,
    Id<UserInternal> CurrentUserId) : IRequest;
