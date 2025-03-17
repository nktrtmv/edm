using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentTypes.Contracts;

public sealed class GetDocumentTypesQueryBffResponse
{
    public required CollectionQueryResponse<DocumentTypeBff> DocumentTypes { get; init; }
}
