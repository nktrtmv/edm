using Edm.Document.Classifier.Presentation.Abstractions;

using Microsoft.Extensions.Caching.Memory;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.DomainActions.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.DomainActions.Converters;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.DomainActions;

internal sealed class DomainActionsClient(DomainActionsService.DomainActionsServiceClient domainActionsService, IMemoryCache memoryCache) : IDomainActionsClient
{
    public async Task<DomainActionsExternal> Get(string domainId, CancellationToken cancellationToken)
    {
        var actions = await memoryCache.GetOrCreateAsync(
            $"{nameof(DomainActionsService.DomainActionsServiceClient.GetDomainActionsAsync)} - {domainId}",
            async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

                var query = new GetDomainActionsQuery
                {
                    DomainId = domainId
                };

                var response = await domainActionsService.GetDomainActionsAsync(query, cancellationToken: cancellationToken);

                return response;
            });

        var result = GetDomainActionsQueryResponseConverter.ToExternal(actions!);

        return result;
    }
}
