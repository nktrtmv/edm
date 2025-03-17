using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts.Templates;

internal static class GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternalConverter
{
    internal static GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternal FromDomain(DocumentTemplate template)
    {
        Id<DocumentTemplateInternal> id = IdConverterFrom<DocumentTemplateInternal>.From(template.Id);

        Id<UserInternal> lastUpdatedByUserId = IdConverterFrom<UserInternal>.From(template.Audit.Brief.UpdatedById);

        var result = new GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternal(
            id,
            template.Name.Value,
            lastUpdatedByUserId,
            template.Status);

        return result;
    }
}
