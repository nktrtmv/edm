using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes.Contracts.DocumentsAttributes;
using Edm.Document.Classifier.Application.DocumentRoles.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentRoles;

public sealed class GetAllDocumentRolesRequestHandlerInternal(IDomainRepository domainRepository)
    : IRequestHandler<GetAllDocumentRolesRequestInternal, GetAllDocumentRolesResponseInternal>
{
    public async Task<GetAllDocumentRolesResponseInternal> Handle(GetAllDocumentRolesRequestInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        DocumentDomain domain = await domainRepository.GetDomainByIdRequired(domainId, cancellationToken);

        List<DocumentDomainDocumentRoleInternal> items = domain.DocumentRoles.Select(
                x => new DocumentDomainDocumentRoleInternal(
                    x.Id.Value,
                    x.Name.Value,
                    x.DisplayName.Value,
                    x.AllowedAttributesConditions.Select(DocumentDomainRegistryRoleInternalConverter.ToInternal).ToList()))
            .ToList();

        var result = new GetAllDocumentRolesResponseInternal(items);

        return result;
    }
}
