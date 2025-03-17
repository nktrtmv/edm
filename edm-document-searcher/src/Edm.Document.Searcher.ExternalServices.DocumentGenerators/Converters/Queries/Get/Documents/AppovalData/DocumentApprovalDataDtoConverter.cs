using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AppovalData.Workflows;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.ApprovalData.Workflows;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AppovalData;

internal static class DocumentApprovalDataDtoConverter
{
    internal static DocumentApprovalDataExternal ToExternal(DocumentApprovalDataDto approvalData)
    {
        DocumentApprovalWorkflowExternal[] workflows =
            approvalData.Workflows.Select(DocumentApprovalWorkflowDtoConverter.ToExternal).ToArray();

        var result = new DocumentApprovalDataExternal(workflows);

        return result;
    }
}
