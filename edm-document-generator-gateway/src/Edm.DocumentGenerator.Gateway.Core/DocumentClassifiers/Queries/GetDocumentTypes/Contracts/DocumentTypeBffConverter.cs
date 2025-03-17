using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentTypes.Contracts;

internal static class DocumentTypeBffConverter
{
    public static DocumentTypeBff ToBff(GetDocumentTypesQueryResponseDocumentType type)
    {
        var result = new DocumentTypeBff
        {
            Id = type.Id,
            Description = type.Description,
            Name = type.Name
        };

        return result;
    }
}
