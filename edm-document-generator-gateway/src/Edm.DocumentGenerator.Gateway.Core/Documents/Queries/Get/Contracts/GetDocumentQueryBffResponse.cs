using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts;

public sealed class GetDocumentQueryBffResponse
{
    public required DocumentDetailedBff? Document { get; init; }
}
