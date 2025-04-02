using Edm.Document.Classifier.Application.DocumentReferences.Types.Queries.GetTypes.Contracts.Types.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Application.DocumentReferences.Types.Contracts;

internal static class DocumentReferenceTypeResponseInternalConverter
{
    public static DocumentReferenceTypeResponseInternal FromDomain(ReferenceType referenceType)
    {
        string? domainId = referenceType.DomainId?.Value;

        Id<DocumentReferenceTypeId> referenceTypeId = IdConverterFrom<DocumentReferenceTypeId>.From(referenceType.ReferenceTypeId);

        Id<DocumentReferenceTypeId>[] parentIds = referenceType.ParentIds.Select(IdConverterFrom<DocumentReferenceTypeId>.From).ToArray();

        ConcurrencyToken<DocumentReferenceTypeResponseInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<DocumentReferenceTypeResponseInternal>.From(referenceType.ConcurrencyToken);

        DocumentReferenceSearchKindInternal searchKind = ReferenceSearchKindInternalConverter.FromDomain(referenceType.SearchKind);

        var result = new DocumentReferenceTypeResponseInternal(
            domainId,
            referenceTypeId,
            referenceType.DisplayName,
            parentIds,
            searchKind,
            concurrencyToken);

        return result;
    }
}
