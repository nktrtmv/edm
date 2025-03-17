using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.Get;

internal static class GetDocumentTemplateQueryConverter
{
    internal static GetDocumentTemplateQueryInternal ToInternal(GetDocumentTemplateQuery request)
    {
        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(request.DomainId);
        var result = new GetDocumentTemplateQueryInternal(domainId, request.Id);

        return result;
    }
}
