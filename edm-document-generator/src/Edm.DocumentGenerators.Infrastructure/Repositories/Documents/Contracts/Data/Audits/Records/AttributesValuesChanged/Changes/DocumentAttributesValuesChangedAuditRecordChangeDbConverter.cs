using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Changes;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.AttributesValuesChanged.Changes.AttributesValues;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.AttributesValuesChanged.Changes;

internal static class DocumentAttributesValuesChangedAuditRecordChangeDbConverter
{
    internal static DocumentAttributesValuesChangedAuditRecordChangeDb FromDomain(AuditRecordChange<DocumentAuditAttributeValue> change)
    {
        DocumentAuditAttributeValueDb from = DocumentAuditAttributeValueDbFromDomainConverter.FromDomain(change.From);

        DocumentAuditAttributeValueDb to = DocumentAuditAttributeValueDbFromDomainConverter.FromDomain(change.To);

        var result = new DocumentAttributesValuesChangedAuditRecordChangeDb
        {
            From = from,
            To = to
        };

        return result;
    }

    internal static AuditRecordChange<DocumentAuditAttributeValue> ToDomain(DocumentAttributesValuesChangedAuditRecordChangeDb change)
    {
        DocumentAuditAttributeValue from = DocumentAuditAttributeValueDbToDomainConverter.ToDomain(change.From);

        DocumentAuditAttributeValue to = DocumentAuditAttributeValueDbToDomainConverter.ToDomain(change.To);

        var result = new AuditRecordChange<DocumentAuditAttributeValue>(from, to);

        return result;
    }
}
