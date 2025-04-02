using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.AttributesValuesChanged.Changes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.DocumentCreated;

internal static class DocumentCreatedAuditRecordDbConverter
{
    internal static DocumentCreatedAuditRecordDb FromDomain(DocumentCreatedAuditRecord record)
    {
        DocumentAttributesValuesChangedAuditRecordChangeDb[] change =
            record.Change.Select(DocumentAttributesValuesChangedAuditRecordChangeDbConverter.FromDomain).ToArray();

        var result = new DocumentCreatedAuditRecordDb
        {
            Change = { change }
        };

        return result;
    }

    internal static DocumentCreatedAuditRecord ToDomain(AuditRecordHeading<Document> heading, DocumentCreatedAuditRecordDb record)
    {
        AuditRecordChange<DocumentAuditAttributeValue>[] change =
            record.Change.Select(DocumentAttributesValuesChangedAuditRecordChangeDbConverter.ToDomain).ToArray();

        DocumentCreatedAuditRecord result =
            DocumentCreatedAuditRecordFactory.CreateFromDb(heading, change);

        return result;
    }
}
