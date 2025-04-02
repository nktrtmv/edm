using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplatesDetails.Converters.Queries.GetDetails;

internal static class GetDetailsDocumentsTemplatesDetailsQueryConverter
{
    internal static GetDetailsDocumentsTemplatesDetailsQueryInternal ToInternal(GetDetailsDocumentsTemplatesDetailsQuery query)
    {
        Id<DocumentTemplateInternal>[] templatesIds =
            query.TemplatesIds.Select(IdConverterFrom<DocumentTemplateInternal>.FromString).ToArray();

        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(query.DomainId);
        var result = new GetDetailsDocumentsTemplatesDetailsQueryInternal(domainId, templatesIds);

        return result;
    }
}
