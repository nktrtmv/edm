using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AppovalData;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AttributesValues;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Audit;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.SigningData;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.StagesTypes;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Services;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.ExternalServices.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents;

internal static class DocumentExternalConverter
{
    internal static DocumentExternal FromDto(DocumentDetailedDto document)
    {
        var id = IdConverterFrom<DocumentExternal>.FromString(document.Id);

        Id<DocumentTemplateExternal> templateId = IdConverterFrom<DocumentTemplateExternal>.FromString(document.TemplateId);

        DocumentAttributeValueDetailedDto[] values = DocumentAttributesValuesCollector
            .Collect(document.AttributesValues)
            .Where(v => v.AsTuple is null && v.AsAttachment is null)
            .ToArray();

        DocumentAttributeValueExternal[] attributesValues =
            values.Select(DocumentAttributeValueExternalFromDtoConverter.FromDto).ToArray();

        var stageType = DocumentStageTypeExternalFromDtoConverter.FromDto(document.StageType);

        var approvalData = DocumentApprovalDataDtoConverter.ToExternal(document.ApprovalData);

        var singingData = DocumentSingingDataDtoConverter.ToExternal(document.SigningData);

        var audit = DocumentAuditExternalConverter.FromDto(document.Audit);

        var status = DocumentStatusExternalConverter.FromDto(document.Status, document.Audit);

        UtcDateTime<DocumentTemplateExternal>? templateUpdateDate = NullableConverter.Convert(
            document.TemplateUpdatedDate,
            UtcDateTimeConverterFrom<DocumentTemplateExternal>.FromTimestamp);

        var result = new DocumentExternal(id, templateId, document.DomainId, attributesValues, status, stageType, approvalData, singingData, audit, templateUpdateDate);

        return result;
    }
}
