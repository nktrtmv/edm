using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.DocumentCreated.Factories;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Factories;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Factories.Audits;

internal static class DocumentAuditFactory
{
    internal static Audit<Document> CreateNew(Id<User> currentUserId, params DocumentAttributeValue[] attributesValues)
    {
        DocumentCreatedAuditRecord documentCreatedRecord = DocumentCreatedAuditRecordFactory.CreateNew(currentUserId, attributesValues);

        Audit<Document> result = AuditFactory<Document>.CreateNew(currentUserId, documentCreatedRecord);

        return result;
    }
}
