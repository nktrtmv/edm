using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows;

namespace Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData;

public sealed record DocumentApprovalDataExternal(DocumentApprovalWorkflowExternal[] Workflows);
