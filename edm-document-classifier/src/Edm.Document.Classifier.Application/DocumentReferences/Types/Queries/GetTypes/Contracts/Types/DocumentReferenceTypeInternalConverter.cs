using Edm.Document.Classifier.Application.DocumentReferences.Queries.GetTypes.Contracts.Types.ReferenceKind;
using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types;

internal static class DocumentReferenceTypeInternalConverter
{
    public static DocumentReferenceTypeInternal FromDomain(DocumentReferenceType type)
    {
        Id<DocumentReferenceTypeId> referenceTypeId = IdConverterFrom<DocumentReferenceTypeId>.FromEnum(type.Id);

        DocumentReferenceSearchKindInternal searchKind =
            ReferenceSearchKindInternalConverter.FromDomain(type.SearchKind);

        DocumentReferenceKindInternal referenceKind = DocumentReferenceKindInternalConverter.FromDomain(type.ReferenceKind);

        Id<DocumentReferenceTypeId>[] parentIds = type.ParentIds.Select(x => IdConverterFrom<DocumentReferenceTypeId>.FromEnum(x)).ToArray();

        var result = new DocumentReferenceTypeInternal(referenceTypeId, searchKind, referenceKind, type.DisplayName, parentIds);

        return result;
    }

    public static DocumentReferenceTypeInternal FromDomain(ReferenceType referenceType)
    {
        Id<DocumentReferenceTypeId> referenceTypeId = IdConverterFrom<DocumentReferenceTypeId>.From(referenceType.ReferenceTypeId);

        DocumentReferenceSearchKindInternal searchKind = ReferenceSearchKindInternalConverter.FromDomain(referenceType.SearchKind);

        Id<DocumentReferenceTypeId>[] parentIds = referenceType.ParentIds.Select(IdConverterFrom<DocumentReferenceTypeId>.From).ToArray();

        var result = new DocumentReferenceTypeInternal(referenceTypeId, searchKind, DocumentReferenceKindInternal.None, referenceType.DisplayName, parentIds);

        return result;
    }

    public static ReferenceType ToDomain(DocumentReferenceTypeInternal referenceType, DomainId domainId, Id<User> createdById)
    {
        Id<ReferenceType> id = Id<ReferenceType>.CreateNew();

        Id<ReferenceType> referenceTypeId = IdConverterFrom<ReferenceType>.From(referenceType.Id);

        Id<ReferenceType>[] parentReferenceTypes = referenceType.ParentIds.Select(IdConverterFrom<ReferenceType>.From).ToArray();

        ConcurrencyToken<ReferenceType> concurrencyToken = ConcurrencyToken<ReferenceType>.Empty;

        UtcDateTime<DateTime> currentDateTime = UtcDateTime<DateTime>.Now;

        DocumentReferenceSearchKind searchKind = DocumentReferenceSearchKind.FixedList;

        var result = new ReferenceType(
            id,
            referenceTypeId,
            domainId,
            referenceType.DisplayName,
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
