using Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts.Templates;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplatesDetails.Converters.Queries.GetDetails.Templates;

internal static class GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateConverter
{
    internal static GetDetailsDocumentsTemplatesDetailsQueryResponseTemplate FromInternal(GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternal response)
    {
        var id = IdConverterTo.ToString(response.Id);

        var lastUpdatedByUserId = IdConverterTo.ToString(response.LastUpdatedByUserId);

        DocumentTemplateStatusDto status = DocumentTemplateStatusDboConverter.FromInternal(response.Status);

        var result = new GetDetailsDocumentsTemplatesDetailsQueryResponseTemplate
        {
            Id = id,
            Name = response.Name,
            LastUpdatedByUserId = lastUpdatedByUserId,
            Status = status
        };

        return result;
    }
}
