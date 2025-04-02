using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetDocumentKinds.Contracts;

public sealed class GetDocumentKindsQueryBffResponse
{
    public required CollectionQueryResponse<DocumentKindBff> DocumentKinds { get; init; }
}
