using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes.Converters.Queries.GetAll;

internal static class GetAllDocumentSystemAttributesQueryConverter
{
    internal static GetAllDocumentSystemAttributesQueryInternal ToInternal(GetAllDocumentSystemAttributesQuery request)
    {
        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(request.DomainId);
        var result = new GetAllDocumentSystemAttributesQueryInternal(domainId);

        return result;
    }
}
