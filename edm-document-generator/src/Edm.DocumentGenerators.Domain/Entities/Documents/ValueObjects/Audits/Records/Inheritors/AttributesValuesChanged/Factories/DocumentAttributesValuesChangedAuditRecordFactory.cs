using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributesValuesChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Args.ValueObjects.Changes;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.Factories;

public static class DocumentAttributesValuesChangedAuditRecordFactory
{
    internal static DocumentAttributesValuesChangedAuditRecord CreateFrom(DocumentAttributesValuesChangedEventArgs args)
    {
        AuditRecordHeading<Document> heading = AuditRecordHeadingFactory<Document>.CreateNew(args.Context.ActorId);

        AuditRecordChange<DocumentAuditAttributeValue>[] change = args.Changes.Select(CreateChange).ToArray();

        DocumentAttributesValuesChangedAuditRecord result = CreateFromDb(heading, change);

        return result;
    }

    private static AuditRecordChange<DocumentAuditAttributeValue> CreateChange(EventChange<DocumentAttributeValue> change)
    {
        DocumentAuditAttributeValue from = DocumentAuditAttributeValueFactory.CreateFrom(change.From);

        DocumentAuditAttributeValue to = DocumentAuditAttributeValueFactory.CreateFrom(change.To);

        var result = new AuditRecordChange<DocumentAuditAttributeValue>(from, to);

        return result;
    }

    public static DocumentAttributesValuesChangedAuditRecord CreateFromDb(
        AuditRecordHeading<Document> heading,
        AuditRecordChange<DocumentAuditAttributeValue>[] change)
    {
        var result = new DocumentAttributesValuesChangedAuditRecord(heading, change);

        return result;
    }
}
