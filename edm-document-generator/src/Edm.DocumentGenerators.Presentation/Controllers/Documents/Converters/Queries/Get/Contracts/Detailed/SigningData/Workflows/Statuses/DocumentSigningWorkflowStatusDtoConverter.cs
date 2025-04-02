using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows.Statuses;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.SigningData.Workflows.Statuses;

internal static class DocumentSigningWorkflowStatusDtoConverter
{
    internal static DocumentSigningWorkflowStatusDto FromInternal(DocumentSigningWorkflowStatusInternal status)
    {
        DocumentSigningWorkflowStatusDto result = status switch
        {
            DocumentSigningWorkflowStatusInternal.InProgress => DocumentSigningWorkflowStatusDto.InProgress,
            DocumentSigningWorkflowStatusInternal.Finished => DocumentSigningWorkflowStatusDto.Finished,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
