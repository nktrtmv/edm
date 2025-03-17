using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceValues.Contracts;

internal sealed class DocumentReferenceValueDbConverter
{
    public static DocumentReferenceValueDb FromDomain(ReferenceValue value)
    {
        var referenceTypeId = int.Parse(value.ReferenceTypeId.Value);

        var createdById = IdConverterTo.ToString(value.CreatedById);

        var updatedById = IdConverterTo.ToString(value.UpdatedById);

        var createdDateTime = UtcDateTimeConverterTo.ToDateTime(value.CreatedDateTime);

        var updatedDateTime = UtcDateTimeConverterTo.ToDateTime(value.UpdatedDateTime);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(value.ConcurrencyToken);

        var result = new DocumentReferenceValueDb
        {
            Id = value.Id.Value,
            DisplayValue = value.DisplayValue,
            DisplaySubValue = value.DisplaySubValue,
            IsHidden = value.IsHidden,
            ReferenceTypeId = referenceTypeId,
            CreatedById = createdById,
            UpdatedById = updatedById,
            CreatedDateTime = createdDateTime,
            UpdatedDateTime = updatedDateTime,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }

    public static ReferenceValue ToDomain(DocumentReferenceValueDb db)
    {
        Id<ReferenceType> referenceTypeId = IdConverterFrom<ReferenceType>.FromInt(db.ReferenceTypeId);

        Id<ReferenceValue> id = IdConverterFrom<ReferenceValue>.FromString(db.Id);

        Id<User> createdById =
            IdConverterFrom<User>.FromString(db.CreatedById);

        Id<User> updatedById =
            IdConverterFrom<User>.FromString(db.UpdatedById);

        var createdDateTime =
            UtcDateTimeConverterFrom<DateTime>.FromUtcDateTime(db.CreatedDateTime);

        var updatedDateTime =
            UtcDateTimeConverterFrom<DateTime>.FromUtcDateTime(db.UpdatedDateTime);

        ConcurrencyToken<ReferenceValue> concurrencyToken =
            ConcurrencyTokenConverterFrom<ReferenceValue>.FromUtcDateTime(db.ConcurrencyToken);

        var result = new ReferenceValue(
            referenceTypeId,
            id,
            db.DisplayValue,
            db.DisplaySubValue ?? string.Empty,
            db.IsHidden,
            createdById,
            updatedById,
            createdDateTime,
            updatedDateTime,
            concurrencyToken);

        return result;
    }
}
