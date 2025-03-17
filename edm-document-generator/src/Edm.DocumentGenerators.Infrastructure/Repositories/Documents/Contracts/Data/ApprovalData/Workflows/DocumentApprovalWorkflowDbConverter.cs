using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApprovalData.Workflows.Statuses;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApprovalData.Workflows;

internal static class DocumentApprovalWorkflowDbConverter
{
    internal static DocumentApprovalWorkflowDb FromDomain(DocumentApprovalWorkflow workflow)
    {
        var id = IdConverterTo.ToString(workflow.Id);

        DocumentApprovalWorkflowStatusDb status = DocumentApprovalWorkflowStatusDbConverter.FromDomain(workflow.Status);

        var result = new DocumentApprovalWorkflowDb
        {
            Id = id,
            Status = status
        };

        return result;
    }

    internal static DocumentApprovalWorkflow ToDomain(DocumentApprovalWorkflowDb workflow)
    {
        Id<DocumentApprovalWorkflow> id = IdConverterFrom<DocumentApprovalWorkflow>.FromString(workflow.Id);

        DocumentApprovalWorkflowStatus status = DocumentApprovalWorkflowStatusDbConverter.ToDomain(workflow.Status);

        DocumentApprovalWorkflow? result = DocumentApprovalWorkflowFactory.FromDb(id, status);

        return result;
    }
}
