using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData;

public sealed class DocumentApprovalDataInternal
{
    internal DocumentApprovalDataInternal(
        UtcDateTime<DocumentTemplateDetailedInternal> attributesVersion,
        DocumentApprovalWorkflowInternal[] workflows)
    {
        AttributesVersion = attributesVersion;
        Workflows = workflows;
    }

    public UtcDateTime<DocumentTemplateDetailedInternal> AttributesVersion { get; }
    public DocumentApprovalWorkflowInternal[] Workflows { get; }
}
