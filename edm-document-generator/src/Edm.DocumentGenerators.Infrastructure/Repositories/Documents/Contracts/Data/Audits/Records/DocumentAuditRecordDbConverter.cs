using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.StatusChanged;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Audits.Records.Headings;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.AttributesValuesChanged;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.DocumentCreated;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records;

internal static class DocumentAuditRecordDbConverter
{
    internal static DocumentAuditRecordDb FromDomain(AuditRecord<Document> record)
    {
        DocumentAuditRecordDb result = record switch
        {
            DocumentAttributesValuesChangedAuditRecord r => new DocumentAuditRecordDb
            {
                AsAttributeValuesChanged = DocumentAttributesValuesChangedAuditRecordDbConverter.FromDomain(r)
            },

            DocumentCreatedAuditRecord r => new DocumentAuditRecordDb
            {
                AsDocumentCreated = DocumentCreatedAuditRecordDbConverter.FromDomain(r)
            },

            DocumentStatusChangedAuditRecord r => new DocumentAuditRecordDb
            {
                AsStatusChanged = DocumentStatusChangedAuditRecordDbConverter.FromDomain(r)
            },

            _ => throw new ArgumentTypeOutOfRangeException(record)
        };

        AuditRecordHeadingDb heading = AuditRecordHeadingDbConverter.FromDomain(record.Heading);

        result.Heading = heading;

        return result;
    }

    internal static AuditRecord<Document> ToDomain(DocumentAuditRecordDb record, DocumentStatusTransition[] statusTransitions)
    {
        AuditRecordHeading<Document> heading = AuditRecordHeadingDbConverter.ToDomain<Document>(record.Heading);

        AuditRecord<Document> result = record.ValueCase switch
        {
            DocumentAuditRecordDb.ValueOneofCase.AsAttributeValuesChanged =>
                DocumentAttributesValuesChangedAuditRecordDbConverter.ToDomain(heading, record.AsAttributeValuesChanged),

            DocumentAuditRecordDb.ValueOneofCase.AsDocumentCreated =>
                DocumentCreatedAuditRecordDbConverter.ToDomain(heading, record.AsDocumentCreated),

            DocumentAuditRecordDb.ValueOneofCase.AsStatusChanged =>
                DocumentStatusChangedAuditRecordDbConverter.ToDomain(heading, record.AsStatusChanged, statusTransitions),

            _ => throw new ArgumentTypeOutOfRangeException(record.ValueCase)
        };

        return result;
    }
}
