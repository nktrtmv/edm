using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Factories;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings.Factories;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated.Factories;

public static class DocumentCreatedAuditRecordFactory
{
    internal static DocumentCreatedAuditRecord CreateNew(Id<User> currentUserId, DocumentAttributeValue[] attributesValues)
    {
        AuditRecordHeading<Document> heading = AuditRecordHeadingFactory<Document>.CreateNew(currentUserId);

        AuditRecordChange<DocumentAuditAttributeValue>[] change = attributesValues
            .Select(CreateChange)
            .OfType<AuditRecordChange<DocumentAuditAttributeValue>>()
            .ToArray();

        DocumentCreatedAuditRecord result = CreateFromDb(heading, change);

        return result;
    }

    private static AuditRecordChange<DocumentAuditAttributeValue>? CreateChange(DocumentAttributeValue attributesValue)
    {
        DocumentAttributeValue defaultAttributeValue = DocumentAttributeValueFactory.CreateFrom(attributesValue.Attribute);

        if (defaultAttributeValue == attributesValue)
        {
            return null;
        }

        DocumentAuditAttributeValue from = DocumentAuditAttributeValueFactory.CreateFrom(defaultAttributeValue);

        DocumentAuditAttributeValue to = DocumentAuditAttributeValueFactory.CreateFrom(attributesValue);

        var result = new AuditRecordChange<DocumentAuditAttributeValue>(from, to);

        return result;
    }

    public static DocumentCreatedAuditRecord CreateFromDb(
        AuditRecordHeading<Document> heading,
        AuditRecordChange<DocumentAuditAttributeValue>[] change)
    {
        var result = new DocumentCreatedAuditRecord(heading, change);

        return result;
    }
}
