using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.DomainActions.Contracts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.DomainActions.Converters;

internal static class GetDomainActionsQueryResponseConverter
{
    public static DomainActionsExternal ToExternal(GetDomainActionsQueryResponse response)
    {
        var result = new DomainActionsExternal(response.DocumentActions.ToArray());

        return result;
    }
}
