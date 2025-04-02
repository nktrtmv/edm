using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;

namespace Edm.Document.Classifier.Application;

public static class ReferenceIdToMetadataConverter
{
    public static string ToMetadata(DocumentReferenceTypeId id) => $$"""{"TypeId":{{(int)id}}}""";
}
