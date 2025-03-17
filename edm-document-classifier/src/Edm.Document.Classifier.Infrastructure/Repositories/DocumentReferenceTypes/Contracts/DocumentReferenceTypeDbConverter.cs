using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.Markers;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts.Data;

using Google.Protobuf;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts;

internal static class DocumentReferenceTypeDbConverter
{
    public static DocumentReferenceTypeDb FromDomain(ReferenceType referenceType)
    {
        int referenceTypeId = int.Parse(referenceType.ReferenceTypeId.Value);

        byte[] data = ToData(referenceType);

        string createdById = IdConverterTo.ToString(referenceType.CreatedById);

        string updatedById = IdConverterTo.ToString(referenceType.UpdatedById);

        DateTime createdDateTime = UtcDateTimeConverterTo.ToDateTime(referenceType.CreatedDateTime);

        DateTime updatedDateTime = UtcDateTimeConverterTo.ToDateTime(referenceType.UpdatedDateTime);

        DateTime concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(referenceType.ConcurrencyToken);

        var result = new DocumentReferenceTypeDb
        {
            Id = referenceType.Id.Value,
            ReferenceTypeId = referenceTypeId,
            DomainId = referenceType.DomainId?.Value,
            DisplayName = referenceType.DisplayName,
            Data = data,
            CreatedById = createdById,
            UpdatedById = updatedById,
            CreatedDateTime = createdDateTime,
            UpdatedDateTime = updatedDateTime,
            ConcurrencyToken = concurrencyToken,
            Version = referenceType.Version
        };

        return result;
    }

    private static byte[] ToData(ReferenceType referenceType)
    {
        int[] parentIds = referenceType.ParentIds.Select(IdConverterTo.ToInt).ToArray();

        var result = new DocumentReferenceTypeDataDb
        {
            ParentIds = { parentIds },
            SearchKind = DocumentReferenceSearchKindConverter.FromDomain(referenceType.SearchKind)
        };

        return result.ToByteArray();
    }

    public static ReferenceType ToDomain(DocumentReferenceTypeDb referenceType)
    {
        Id<ReferenceType> id = IdConverterFrom<ReferenceType>.FromString(referenceType.Id);

        Id<ReferenceType> referenceTypeId = IdConverterFrom<ReferenceType>.FromInt(referenceType.ReferenceTypeId);

        DomainId? domainId = string.IsNullOrWhiteSpace(referenceType.DomainId) ? null : DomainId.Parse(referenceType.DomainId);

        Data data = ToData(referenceType.Data);

        Id<User> createdById =
            IdConverterFrom<User>.FromString(referenceType.CreatedById);

        Id<User> updatedById =
            IdConverterFrom<User>.FromString(referenceType.UpdatedById);

        UtcDateTime<DateTime> createdDateTime =
            UtcDateTimeConverterFrom<DateTime>.FromUtcDateTime(referenceType.CreatedDateTime);

        UtcDateTime<DateTime> updatedDateTime =
            UtcDateTimeConverterFrom<DateTime>.FromUtcDateTime(referenceType.UpdatedDateTime);

        ConcurrencyToken<ReferenceType> concurrencyToken =
            ConcurrencyTokenConverterFrom<ReferenceType>.FromUtcDateTime(referenceType.ConcurrencyToken);

        var result = new ReferenceType(
            id,
            referenceTypeId,
            domainId,
            referenceType.DisplayName,
            data.ParentIds,
            data.SearchKind,
            createdById,
            updatedById,
            createdDateTime,
            updatedDateTime,
            concurrencyToken,
            referenceType.Version);

        return result;
    }

    private static Data ToData(byte[] bytes)
    {
        DocumentReferenceTypeDataDb data = DocumentReferenceTypeDataDb.Parser.ParseFrom(bytes);

        Id<ReferenceType>[] parentIds = data.ParentIds.Select(IdConverterFrom<ReferenceType>.FromInt).ToArray();

        DocumentReferenceSearchKind searchKind = DocumentReferenceSearchKindConverter.ToDomain(data.SearchKind);

        var result = new Data(parentIds, searchKind);

        return result;
    }

    private readonly record struct Data(Id<ReferenceType>[] ParentIds, DocumentReferenceSearchKind SearchKind);
}
