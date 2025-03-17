using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data;

public sealed class DocumentApprovalData
{
    internal DocumentApprovalData(UtcDateTime<DocumentTemplate> attributesVersion, DocumentApprovalWorkflow[] workflows)
    {
        AttributesVersion = attributesVersion;
        Workflows = workflows;
    }

    public UtcDateTime<DocumentTemplate> AttributesVersion { get; }
    public DocumentApprovalWorkflow[] Workflows { get; internal set; }
}
