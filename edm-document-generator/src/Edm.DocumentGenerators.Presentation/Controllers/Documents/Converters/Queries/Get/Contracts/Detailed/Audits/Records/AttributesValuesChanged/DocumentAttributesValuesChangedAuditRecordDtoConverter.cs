using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged.Changes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged;

internal static class DocumentAttributesValuesChangedAuditRecordDtoConverter
{
    internal static DocumentAttributesValuesChangedAuditRecordDto FromDomain(DocumentAttributesValuesChangedAuditRecordInternal record)
    {
        DocumentAttributesValuesChangedAuditRecordChangeDto[] change =
            record.Change.Select(DocumentAttributesValuesChangedAuditRecordChangeDtoConverter.FromDomain).ToArray();

        var result = new DocumentAttributesValuesChangedAuditRecordDto
        {
            Change = { change }
        };

        return result;
    }
}
