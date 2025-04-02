using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes.Contracts;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes.Contracts.DocumentsAttributes;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes;

[UsedImplicitly]
internal sealed class GetDomainRegistryRolesQueryInternalHandler(IDomainRepository repository)
    : IRequestHandler<GetDomainRegistryRolesInternalQuery, GetDomainRegistryRolesInternalResponse>
{
    public async Task<GetDomainRegistryRolesInternalResponse> Handle(
        GetDomainRegistryRolesInternalQuery request,
        CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        DocumentDomain domain = await repository.GetDomainByIdRequired(domainId, cancellationToken);

        IEnumerable<DocumentDomainRegistryRole> requestedRoles = request.AllowOnlyUserMarkAttributeWithRole
            ? domain.RegistryRoles.Where(x => x.Kind == DocumentRegistryRoleKind.Attribute)
            : domain.RegistryRoles;
        DomainRegistryRoleInternal[] roles = requestedRoles
            .Select(DocumentDomainRegistryRoleInternalConverter.FromDomain)
            .ToArray();

        var result = new GetDomainRegistryRolesInternalResponse(roles);

        return result;
    }
}
