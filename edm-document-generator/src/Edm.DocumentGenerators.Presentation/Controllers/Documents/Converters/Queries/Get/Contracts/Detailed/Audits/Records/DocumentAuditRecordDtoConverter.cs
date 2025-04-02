using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.DocumentCreated;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Audits.Records.Headings;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.DocumentCreated;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits.Records;

internal static class DocumentAuditRecordDtoConverter
{
    internal static DocumentAuditRecordDto FromDomain(AuditRecordInternal<DocumentDetailedInternal> record)
    {
        DocumentAuditRecordDto result = record switch
        {
            DocumentAttributesValuesChangedAuditRecordInternal r => new DocumentAuditRecordDto
            {
                AsAttributeValuesChanged = DocumentAttributesValuesChangedAuditRecordDtoConverter.FromDomain(r)
            },

            DocumentCreatedAuditRecordInternal r => new DocumentAuditRecordDto
            {
                AsDocumentCreated = DocumentCreatedAuditRecordDtoConverter.FromInternal(r)
            },

            DocumentStatusChangedAuditRecordInternal r => new DocumentAuditRecordDto
            {
                AsStatusChanged = DocumentStatusChangedAuditRecordDtoConverter.FromInternal(r)
            },

            _ => throw new ArgumentTypeOutOfRangeException(record)
        };

        AuditRecordHeadingDto heading = AuditRecordHeadingDtoConverter.FromInternal(record.Heading);

        result.Heading = heading;

        return result;
    }
}
