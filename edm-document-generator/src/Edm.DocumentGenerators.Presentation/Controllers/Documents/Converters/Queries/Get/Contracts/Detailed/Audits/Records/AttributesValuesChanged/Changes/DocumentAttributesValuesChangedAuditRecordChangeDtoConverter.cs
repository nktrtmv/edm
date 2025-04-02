using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Commands.Contracts.AttributesValues;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged.Changes;

internal static class DocumentAttributesValuesChangedAuditRecordChangeDtoConverter
{
    internal static DocumentAttributesValuesChangedAuditRecordChangeDto FromDomain(AuditRecordChangeInternal<DocumentAttributeValueInternal> change)
    {
        DocumentAttributeValueDto from = DocumentAttributeValueDtoConverter.ToDto(change.From);
        DocumentAttributeValueDto to = DocumentAttributeValueDtoConverter.ToDto(change.To);

        var result = new DocumentAttributesValuesChangedAuditRecordChangeDto
        {
            From = from,
            To = to
        };

        return result;
    }
}
