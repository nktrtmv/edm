using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.Slim;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts;

public sealed class GetAllDocumentTemplatesQueryInternalResponse
{
    internal GetAllDocumentTemplatesQueryInternalResponse(DocumentTemplateSlimInternal[] templates)
    {
        Templates = templates;
    }

    public DocumentTemplateSlimInternal[] Templates { get; }
}
