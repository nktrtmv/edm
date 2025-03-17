using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.LinksKinds;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.DocumentsLinks.Kinds;

internal static class DocumentLinkKindDtoConverter
{
    internal static DocumentLinkKindDto FromInternal(DocumentLinkKind kind)
    {
        DocumentLinkKindDto result = kind switch
        {
            DocumentLinkKind.Parent => DocumentLinkKindDto.Parent,
            DocumentLinkKind.Master => DocumentLinkKindDto.Master,
            DocumentLinkKind.External => DocumentLinkKindDto.External,
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
        };

        return result;
    }

    internal static DocumentLinkKind ToInternal(DocumentLinkKindDto kind)
    {
        DocumentLinkKind result = kind switch
        {
            DocumentLinkKindDto.Parent => DocumentLinkKind.Parent,
            DocumentLinkKindDto.Master => DocumentLinkKind.Master,
            DocumentLinkKindDto.External => DocumentLinkKind.External,
            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
        };

        return result;
    }
}
