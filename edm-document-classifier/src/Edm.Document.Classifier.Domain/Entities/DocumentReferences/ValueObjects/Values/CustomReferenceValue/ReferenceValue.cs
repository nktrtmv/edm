using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;

public sealed record ReferenceValue(
    Id<ReferenceType> ReferenceTypeId,
    Id<ReferenceValue> Id,
    string DisplayValue,
    string DisplaySubValue,
    bool IsHidden,
    Id<User> CreatedById,
    Id<User> UpdatedById,
    UtcDateTime<DateTime> CreatedDateTime,
    UtcDateTime<DateTime> UpdatedDateTime,
    ConcurrencyToken<ReferenceValue> ConcurrencyToken)
{
    public Id<ReferenceType> ReferenceTypeId { get; } = ReferenceTypeId;
    public Id<ReferenceValue> Id { get; } = Id;
    public string DisplayValue { get; private set; } = DisplayValue;
    public string DisplaySubValue { get; private set; } = DisplaySubValue;
    public bool IsHidden { get; private set; } = IsHidden;
    public Id<User> CreatedById { get; } = CreatedById;
    public Id<User> UpdatedById { get; private set; } = UpdatedById;
    public UtcDateTime<DateTime> CreatedDateTime { get; } = CreatedDateTime;
    public UtcDateTime<DateTime> UpdatedDateTime { get; private set; } = UpdatedDateTime;
    public ConcurrencyToken<ReferenceValue> ConcurrencyToken { get; } = ConcurrencyToken;

    public void Update(
        string displayValue,
        string displaySubValue,
        bool isHidden,
        Id<User> currentUserId)
    {
        DisplayValue = displayValue;
        DisplaySubValue = displaySubValue;
        IsHidden = isHidden;
        UpdatedById = currentUserId;
        UpdatedDateTime = UtcDateTime<DateTime>.Now;
    }
};
