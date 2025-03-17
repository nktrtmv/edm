using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.ApprovalData.Workflows;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.ApprovalData;

internal static class DocumentApprovalDataDtoConverter
{
    internal static DocumentApprovalDataDto FromInternal(DocumentApprovalDataInternal data)
    {
        DocumentApprovalWorkflowDto[] workflows = data.Workflows.Select(DocumentApprovalWorkflowDtoConverter.FromInternal).ToArray();

        var result = new DocumentApprovalDataDto
        {
            AttributesVersion = UtcDateTimeConverterTo.ToTimeStamp(data.AttributesVersion),
            Workflows = { workflows }
        };

        return result;
    }
}
