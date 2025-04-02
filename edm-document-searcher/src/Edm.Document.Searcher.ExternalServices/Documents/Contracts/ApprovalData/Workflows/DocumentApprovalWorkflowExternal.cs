using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows.Statuses;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows;

public sealed record DocumentApprovalWorkflowExternal(
    Id<DocumentApprovalWorkflowExternal> Id,
    DocumentApprovalWorkflowStatusExternal Status);
