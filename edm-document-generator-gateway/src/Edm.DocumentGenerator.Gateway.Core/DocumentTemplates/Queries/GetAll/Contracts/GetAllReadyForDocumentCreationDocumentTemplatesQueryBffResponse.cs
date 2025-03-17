using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts.Slim;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts;

public sealed class GetAllReadyForDocumentCreationDocumentTemplatesQueryBffResponse
{
    public required CollectionQueryResponse<DocumentTemplateSlimBff> Templates { get; init; }
}
