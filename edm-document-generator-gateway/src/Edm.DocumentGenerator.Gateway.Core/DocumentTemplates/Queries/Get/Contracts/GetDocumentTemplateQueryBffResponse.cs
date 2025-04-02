using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Get.Contracts;

public sealed class GetDocumentTemplateQueryBffResponse
{
    public DocumentTemplateDetailedBff? Template { get; init; }
}
