using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated;

public sealed record DocumentCreatedAuditRecord(
    AuditRecordHeading<Document> Heading,
    AuditRecordChange<DocumentAuditAttributeValue>[] Change)
    : AuditChangeRecord<Document, AuditRecordChange<DocumentAuditAttributeValue>[]>(Heading, Change);
