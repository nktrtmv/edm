using Edm.Document.Classifier.Application.DomainActions.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DomainActions.Converters;

internal static class GetDomainActionsQueryConverter
{
    public static GetDomainActionsQueryInternal ToInternal(GetDomainActionsQuery query)
    {
        var result = new GetDomainActionsQueryInternal(query.DomainId);

        return result;
    }
}
