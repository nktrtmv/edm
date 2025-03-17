using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.StatusesTransitionsParametersValues;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged.Changes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged;

internal static class DocumentStatusChangedAuditRecordDtoConverter
{
    internal static DocumentStatusChangedAuditRecordDto FromInternal(DocumentStatusChangedAuditRecordInternal record)
    {
        DocumentStatusChangedAuditRecordChangeDto change =
            DocumentStatusChangedAuditRecordChangeDtoConverter.FromInternal(record.Change);

        DocumentStatusTransitionParameterValueDto[] statusTransitionParametersValues = record.StatusTransitionParametersValues
            .Select(DocumentStatusTransitionParameterValueDtoConverter.FromInternal)
            .ToArray();

        var result = new DocumentStatusChangedAuditRecordDto
        {
            Change = change,
            StatusTransitionParametersValues = { statusTransitionParametersValues }
        };

        return result;
    }
}
