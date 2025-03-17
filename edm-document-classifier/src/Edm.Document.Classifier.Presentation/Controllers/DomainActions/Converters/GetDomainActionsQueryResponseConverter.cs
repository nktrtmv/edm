using Edm.Document.Classifier.Application.DomainActions.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;

namespace Edm.Document.Classifier.Presentation.Controllers.DomainActions.Converters;

internal static class GetDomainActionsQueryResponseConverter
{
    public static GetDomainActionsQueryResponse FromInternal(GetDomainActionsQueryResponseInternal response)
    {
        var result = new GetDomainActionsQueryResponse
        {
            DocumentActions = { response.DocumentActions }
        };

        return result;
    }
}
