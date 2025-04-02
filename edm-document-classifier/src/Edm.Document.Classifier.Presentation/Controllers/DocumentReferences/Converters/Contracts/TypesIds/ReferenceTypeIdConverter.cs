using System.Text.Json;

using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentReferences.Converters.Contracts.TypesIds;

internal static class ReferenceTypeIdConverter
{
    internal static string ToDto(Id<DocumentReferenceTypeId> referenceTypeId)
    {
        var typeId = IdConverterTo.ToInt(referenceTypeId);

        var data = new ReferenceTypeData
        {
            TypeId = typeId
        };

        var result = JsonSerializer.Serialize(data);

        return result;
    }

    internal static Id<DocumentReferenceTypeId> FromDto(string referenceTypeId)
    {
        var data = JsonSerializer.Deserialize<ReferenceTypeData>(referenceTypeId)!;

        var result = IdConverterFrom<DocumentReferenceTypeId>.FromString(data.TypeId.ToString());

        return result;
    }

    private sealed class ReferenceTypeData
    {
        public long TypeId { get; init; }
    }
}
