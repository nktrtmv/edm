using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.Factories;

public static class DocumentApprovalDataFactory
{
    public static DocumentApprovalData CreateFrom(UtcDateTime<DocumentTemplate> attributesVersion)
    {
        var result = new DocumentApprovalData(attributesVersion, Array.Empty<DocumentApprovalWorkflow>());

        return result;
    }

    public static DocumentApprovalData CreateFromDb(UtcDateTime<DocumentTemplate> attributesVersion, DocumentApprovalWorkflow[] workflows)
    {
        var result = new DocumentApprovalData(attributesVersion, workflows);

        return result;
    }
}
