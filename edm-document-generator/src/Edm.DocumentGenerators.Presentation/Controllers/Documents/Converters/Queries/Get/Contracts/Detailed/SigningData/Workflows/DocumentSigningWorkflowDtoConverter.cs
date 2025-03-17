using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.SigningData.Workflows.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.SigningData.Workflows;

internal static class DocumentSigningWorkflowDtoConverter
{
    internal static DocumentSigningWorkflowDto FromInternal(DocumentSigningWorkflowInternal workflow)
    {
        var id = IdConverterTo.ToString(workflow.Id);

        DocumentSigningWorkflowStatusDto status = DocumentSigningWorkflowStatusDtoConverter.FromInternal(workflow.Status);

        var result = new DocumentSigningWorkflowDto
        {
            Id = id,
            Status = status
        };

        return result;
    }
}
