using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.SigningData.Workflows;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.SigningData;

internal static class DocumentSigningDataDtoConverter
{
    internal static DocumentSigningDataDto FromInternal(DocumentSigningDataInternal data)
    {
        DocumentSigningWorkflowDto[] workflows = data.Workflows.Select(DocumentSigningWorkflowDtoConverter.FromInternal).ToArray();

        var result = new DocumentSigningDataDto
        {
            Workflows = { workflows }
        };

        return result;
    }
}
