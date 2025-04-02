using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.SigningData.Workflows.Statuses;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.SigningData.Workflows;

internal static class DocumentSigningWorkflowDbConverter
{
    internal static DocumentSigningWorkflowDb FromDomain(DocumentSigningWorkflow workflow)
    {
        var id = IdConverterTo.ToString(workflow.Id);

        DocumentSigningWorkflowStatusDb status = DocumentSigningWorkflowStatusDbConverter.FromDomain(workflow.Status);

        var result = new DocumentSigningWorkflowDb
        {
            Id = id,
            Status = status,
            IsSelfSigned = workflow.IsSelfSigned
        };

        return result;
    }

    internal static DocumentSigningWorkflow ToDomain(DocumentSigningWorkflowDb workflow)
    {
        Id<DocumentSigningWorkflow> id = IdConverterFrom<DocumentSigningWorkflow>.FromString(workflow.Id);

        DocumentSigningWorkflowStatus status = DocumentSigningWorkflowStatusDbConverter.ToDomain(workflow.Status);

        DocumentSigningWorkflow? result = DocumentSigningWorkflowFactory.CreateFromDb(id, status, workflow.IsSelfSigned);

        return result;
    }
}
