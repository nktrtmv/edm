using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains;

public sealed class GetAllDomainsInternalQueryHandler(IDomainRepository domainRepository)
    : IRequestHandler<GetAllDomainsInternalQuery, GetAllDomainsInternalResponse>
{
    public async Task<GetAllDomainsInternalResponse> Handle(GetAllDomainsInternalQuery request, CancellationToken cancellationToken)
    {
        var domains = await domainRepository.GetAllDomains(cancellationToken);

        var items = domains.Value.Select(DocumentDomainSettingsInternalConverter.ToInternal).ToList();

        var result = new GetAllDomainsInternalResponse(items);

        return result;
    }
}
