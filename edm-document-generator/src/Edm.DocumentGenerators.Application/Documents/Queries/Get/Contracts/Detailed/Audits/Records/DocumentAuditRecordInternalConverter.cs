using Edm.DocumentGenerators.Application.Contracts.Statuses.Services;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.DocumentCreated;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.StatusChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.StatusChanged;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records;

internal static class DocumentAuditRecordInternalConverter
{
    internal static AuditRecordInternal<DocumentDetailedInternal> FromDomain(AuditRecord<Document> record, DocumentStatusInternalEnricher statusEnricher)
    {
        AuditRecordInternal<DocumentDetailedInternal> result = record switch
        {
            DocumentAttributesValuesChangedAuditRecord r =>
                DocumentAttributesValuesChangedAuditRecordInternalFromDomainConverter.FromDomain(r),

            DocumentCreatedAuditRecord r =>
                DocumentCreatedAuditRecordInternalConverter.FromDomain(r),

            DocumentStatusChangedAuditRecord r =>
                DocumentStatusChangedAuditRecordInternalConverter.FromDomain(r, statusEnricher),

            _ => throw new ArgumentTypeOutOfRangeException(record)
        };

        return result;
    }
}
