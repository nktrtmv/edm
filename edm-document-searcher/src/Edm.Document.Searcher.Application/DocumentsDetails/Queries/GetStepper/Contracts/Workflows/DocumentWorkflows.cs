using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Workflows;

internal sealed record DocumentWorkflows(
    EntitiesApprovalWorkflowExternal[] Approval,
    SigningWorkflowExternal[] Signing);
