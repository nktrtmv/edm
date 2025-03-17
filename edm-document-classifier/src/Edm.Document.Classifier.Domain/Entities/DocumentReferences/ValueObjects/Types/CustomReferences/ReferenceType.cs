using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;

public sealed class ReferenceType(
    Id<ReferenceType> id,
    Id<ReferenceType> referenceTypeId,
    DomainId? domainId,
    string displayName,
    Id<ReferenceType>[] parentIds,
    DocumentReferenceSearchKind searchKind,
    Id<User> createdById,
    Id<User> updatedById,
    UtcDateTime<DateTime> createdDateTime,
    UtcDateTime<DateTime> updatedDateTime,
    ConcurrencyToken<ReferenceType> concurrencyToken,
    int version)
{
    public Id<ReferenceType> Id = id;
    public Id<ReferenceType> ReferenceTypeId { get; } = referenceTypeId;
    public DomainId? DomainId { get; private set; } = domainId;
    public string DisplayName { get; private set; } = displayName;
    public Id<ReferenceType>[] ParentIds { get; private set; } = parentIds;
    public DocumentReferenceSearchKind SearchKind { get; } = searchKind;
    public Id<User> CreatedById { get; } = createdById;
    public Id<User> UpdatedById { get; private set; } = updatedById;
    public UtcDateTime<DateTime> CreatedDateTime { get; } = createdDateTime;
    public UtcDateTime<DateTime> UpdatedDateTime { get; private set; } = updatedDateTime;
    public ConcurrencyToken<ReferenceType> ConcurrencyToken { get; } = concurrencyToken;
    public int Version { get; private set; } = version;

    public void Update(
        DomainId? domainId,
        string displayName,
        Id<ReferenceType>[] parentIds,
        Id<User> currentUserId)
    {
        DomainId = domainId;
        DisplayName = displayName;
        ParentIds = parentIds;
        UpdatedById = currentUserId;
        UpdatedDateTime = UtcDateTime<DateTime>.Now;
        Version += 1;
    }
}
