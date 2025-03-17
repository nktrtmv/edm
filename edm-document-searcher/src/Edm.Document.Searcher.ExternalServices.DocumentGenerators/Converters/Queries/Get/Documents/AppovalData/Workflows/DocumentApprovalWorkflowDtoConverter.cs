using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AppovalData.Workflows.Statuses;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows.Statuses;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AppovalData.Workflows;

internal static class DocumentApprovalWorkflowDtoConverter
{
    internal static DocumentApprovalWorkflowExternal ToExternal(DocumentApprovalWorkflowDto approvalWorkflow)
    {
        Id<DocumentApprovalWorkflowExternal> id = IdConverterFrom<DocumentApprovalWorkflowExternal>.FromString(approvalWorkflow.Id);

        DocumentApprovalWorkflowStatusExternal status = DocumentApprovalWorkflowStatusDtoConverter.ToExternal(approvalWorkflow.Status);

        var result = new DocumentApprovalWorkflowExternal(id, status);

        return result;
    }
}
