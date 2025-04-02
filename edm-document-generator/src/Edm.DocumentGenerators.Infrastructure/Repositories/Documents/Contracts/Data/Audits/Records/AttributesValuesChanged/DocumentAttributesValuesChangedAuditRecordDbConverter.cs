using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.AttributesValuesChanged.Changes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.AttributesValuesChanged;

internal static class DocumentAttributesValuesChangedAuditRecordDbConverter
{
    internal static DocumentAttributesValuesChangedAuditRecordDb FromDomain(DocumentAttributesValuesChangedAuditRecord record)
    {
        DocumentAttributesValuesChangedAuditRecordChangeDb[] change =
            record.Change.Select(DocumentAttributesValuesChangedAuditRecordChangeDbConverter.FromDomain).ToArray();

        var result = new DocumentAttributesValuesChangedAuditRecordDb
        {
            Change = { change }
        };

        return result;
    }

    internal static DocumentAttributesValuesChangedAuditRecord ToDomain(
        AuditRecordHeading<Document> heading,
        DocumentAttributesValuesChangedAuditRecordDb record)
    {
        AuditRecordChange<DocumentAuditAttributeValue>[] change =
            record.Change.Select(DocumentAttributesValuesChangedAuditRecordChangeDbConverter.ToDomain).ToArray();

        DocumentAttributesValuesChangedAuditRecord result =
            DocumentAttributesValuesChangedAuditRecordFactory.CreateFromDb(heading, change);

        return result;
    }
}
