using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApprovalData.Workflows;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApprovalData;

internal static class DocumentApprovalDataDbConverter
{
    internal static DocumentApprovalDataDb FromDomain(DocumentApprovalData data)
    {
        Timestamp attributesVersion = UtcDateTimeConverterTo.ToTimeStamp(data.AttributesVersion);

        DocumentApprovalWorkflowDb[] workflows = data.Workflows.Select(DocumentApprovalWorkflowDbConverter.FromDomain).ToArray();

        var result = new DocumentApprovalDataDb
        {
            AttributesVersion = attributesVersion,
            Workflows = { workflows }
        };

        return result;
    }

    internal static DocumentApprovalData ToDomain(DocumentApprovalDataDb data)
    {
        UtcDateTime<DocumentTemplate> attributesVersion =
            UtcDateTimeConverterFrom<DocumentTemplate>.FromTimestamp(data.AttributesVersion);

        DocumentApprovalWorkflow[] workflows = data.Workflows.Select(DocumentApprovalWorkflowDbConverter.ToDomain).ToArray();

        DocumentApprovalData result = DocumentApprovalDataFactory.CreateFromDb(attributesVersion, workflows);

        return result;
    }
}
