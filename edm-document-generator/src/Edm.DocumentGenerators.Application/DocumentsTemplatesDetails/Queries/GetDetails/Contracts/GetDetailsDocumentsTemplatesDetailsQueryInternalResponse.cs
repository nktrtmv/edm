using Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts.Templates;

namespace Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts;

public sealed class GetDetailsDocumentsTemplatesDetailsQueryInternalResponse
{
    internal GetDetailsDocumentsTemplatesDetailsQueryInternalResponse(GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternal[] templates)
    {
        Templates = templates;
    }

    public GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternal[] Templates { get; }
}
