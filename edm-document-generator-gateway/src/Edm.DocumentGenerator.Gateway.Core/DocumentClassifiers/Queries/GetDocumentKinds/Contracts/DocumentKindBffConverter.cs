using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds.Contracts;

internal static class DocumentKindBffConverter
{
    public static DocumentKindBff ToBff(GetDocumentKindsQueryResponseDocumentKind kind)
    {
        var result = new DocumentKindBff
        {
            Id = kind.Id,
            Description = kind.Description,
            Name = kind.Name
        };

        return result;
    }
}
