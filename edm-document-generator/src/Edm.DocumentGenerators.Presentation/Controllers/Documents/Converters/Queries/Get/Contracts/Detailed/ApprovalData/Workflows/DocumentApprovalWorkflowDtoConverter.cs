using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.ApprovalData.Workflows.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;

internal static class DocumentApprovalWorkflowDtoConverter
{
    internal static DocumentApprovalWorkflowDto FromInternal(DocumentApprovalWorkflowInternal workflow)
    {
        var id = IdConverterTo.ToString(workflow.Id);

        DocumentApprovalWorkflowStatusDto status = DocumentApprovalWorkflowStatusDtoConverter.FromInternal(workflow.Status);

        var result = new DocumentApprovalWorkflowDto
        {
            Id = id,
            Status = status
        };

        return result;
    }
}
