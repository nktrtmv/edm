using Edm.Document.Classifier.Domain.Entities.DocumentDomains;

namespace Edm.Document.Classifier.Application.DomainActions.Contracts;

internal static class GetDomainActionsQueryResponseInternalConverter
{
    public static GetDomainActionsQueryResponseInternal FromDomain(DocumentDomain domain)
    {
        int[] actions = domain.Actions.Select(a => (int) a).ToArray();

        var result = new GetDomainActionsQueryResponseInternal(actions);

        return result;
    }
}
