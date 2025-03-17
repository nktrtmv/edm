using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.LinksKinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Contracts.LinksKinds;

internal static class DocumentLinkKindDbConverter
{
    internal static DocumentLinkKindDb FromDomain(DocumentLinkKind kind)
    {
        DocumentLinkKindDb result = kind switch
        {
            DocumentLinkKind.Parent => DocumentLinkKindDb.Parent,
            DocumentLinkKind.Master => DocumentLinkKindDb.Master,
            DocumentLinkKind.External => DocumentLinkKindDb.External,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }

    internal static DocumentLinkKind ToDomain(DocumentLinkKindDb kind)
    {
        DocumentLinkKind result = kind switch
        {
            DocumentLinkKindDb.Parent => DocumentLinkKind.Parent,
            DocumentLinkKindDb.Master => DocumentLinkKind.Master,
            DocumentLinkKindDb.External => DocumentLinkKind.External,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
