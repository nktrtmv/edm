using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Domain.Entities.DocumentReferences.Factories;

public static class DocumentReferenceTypeFactory
{
    public static ReferenceType CreateNew(
        DomainId? domainId,
        Id<ReferenceType> referenceTypeId,
        string displayName,
        Id<ReferenceType>[] parentIds,
        Id<User> createdById)
    {
        Id<ReferenceType> id = Id<ReferenceType>.CreateNew();

        Id<ReferenceType>[] parentReferenceTypes = parentIds.Select(IdConverterFrom<ReferenceType>.From).ToArray();

        ConcurrencyToken<ReferenceType> concurrencyToken = ConcurrencyToken<ReferenceType>.Empty;

        UtcDateTime<DateTime> currentDateTime = UtcDateTime<DateTime>.Now;

        DocumentReferenceSearchKind searchKind = DocumentReferenceSearchKind.Search;

        var result = new ReferenceType(
            id,
            referenceTypeId,
            domainId,
            displayName,
            parentReferenceTypes,
            searchKind,
            createdById,
            createdById,
            currentDateTime,
            currentDateTime,
            concurrencyToken,
            0);

        return result;
    }
}
