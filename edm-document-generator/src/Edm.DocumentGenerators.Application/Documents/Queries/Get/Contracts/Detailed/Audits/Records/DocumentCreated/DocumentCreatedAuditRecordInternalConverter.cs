using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.DocumentCreated;

internal static class DocumentCreatedAuditRecordInternalConverter
{
    internal static DocumentCreatedAuditRecordInternal FromDomain(DocumentCreatedAuditRecord record)
    {
        AuditRecordHeadingInternal<DocumentDetailedInternal> heading = AuditRecordHeadingInternalConverter<DocumentDetailedInternal>.FromDomain(record.Heading);

        AuditRecordChangeInternal<DocumentAttributeValueInternal>[] change = record.Change.Select(ToChange).ToArray();

        var result = new DocumentCreatedAuditRecordInternal(heading, change);

        return result;
    }

    private static AuditRecordChangeInternal<DocumentAttributeValueInternal> ToChange(AuditRecordChange<DocumentAuditAttributeValue> change)
    {
        AuditRecordChangeInternal<DocumentAttributeValueInternal> result =
            AuditRecordChangeInternalConverter<DocumentAttributeValueInternal>.FromDomain(
                change,
                DocumentAuditAttributeValueInternalFromDomainConverter.FromDomain);

        return result;
    }
}
