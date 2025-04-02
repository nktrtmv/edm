using Edm.Document.Classifier.Application.DomainActions.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DomainActions;

[UsedImplicitly]
public class GetDomainActionsQueryInternalHandler(IDomainRepository domainRepository)
    : IRequestHandler<GetDomainActionsQueryInternal, GetDomainActionsQueryResponseInternal>
{
    public async Task<GetDomainActionsQueryResponseInternal> Handle(GetDomainActionsQueryInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);

        DocumentDomain domain = await domainRepository.GetDomainByIdRequired(domainId, cancellationToken);

        GetDomainActionsQueryResponseInternal result = GetDomainActionsQueryResponseInternalConverter.FromDomain(domain);

        return result;
    }
}
