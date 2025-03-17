using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData;

internal static class DocumentApprovalDataInternalConverter
{
    internal static DocumentApprovalDataInternal FromDomain(DocumentApprovalData approvalData)
    {
        UtcDateTime<DocumentTemplateDetailedInternal> attributesVersion =
            UtcDateTimeConverterFrom<DocumentTemplateDetailedInternal>.From(approvalData.AttributesVersion);

        DocumentApprovalWorkflowInternal[] workflows = approvalData.Workflows.Select(DocumentApprovalWorkflowInternalConverter.FromDomain).ToArray();

        var result = new DocumentApprovalDataInternal(attributesVersion, workflows);

        return result;
    }
}
