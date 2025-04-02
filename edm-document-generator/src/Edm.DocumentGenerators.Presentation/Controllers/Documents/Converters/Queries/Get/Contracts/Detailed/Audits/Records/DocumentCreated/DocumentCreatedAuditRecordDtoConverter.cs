using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.DocumentCreated;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged.Changes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.DocumentCreated;

internal static class DocumentCreatedAuditRecordDtoConverter
{
    internal static DocumentCreatedAuditRecordDto FromInternal(DocumentCreatedAuditRecordInternal record)
    {
        DocumentAttributesValuesChangedAuditRecordChangeDto[] change =
            record.Change.Select(DocumentAttributesValuesChangedAuditRecordChangeDtoConverter.FromDomain).ToArray();

        var result = new DocumentCreatedAuditRecordDto
        {
            Change = { change }
        };

        return result;
    }
}
