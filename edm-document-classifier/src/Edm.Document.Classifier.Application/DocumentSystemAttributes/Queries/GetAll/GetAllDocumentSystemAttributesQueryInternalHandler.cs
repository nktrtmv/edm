using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts;
using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes;
using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Abstractions.Data;
using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Inheritors;
using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllDocumentSystemAttributesQueryInternalHandler(IDomainRepository domainRepository)
    : IRequestHandler<GetAllDocumentSystemAttributesQueryInternal, GetAllDocumentSystemAttributesQueryInternalResponse>
{
    public async Task<GetAllDocumentSystemAttributesQueryInternalResponse> Handle(
        GetAllDocumentSystemAttributesQueryInternal request,
        CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        DocumentDomain domain = await domainRepository.GetDomainByIdRequired(domainId, cancellationToken);

        DocumentSystemAttributeInternal[] attributes = domain.SystemAttributes.Select(ToInternal).ToArray();

        var result = new GetAllDocumentSystemAttributesQueryInternalResponse(attributes);

        return result;
    }

    private static DocumentSystemAttributeInternal ToInternal(DocumentDomainSystemAttribute model)
    {
        var data = new DocumentSystemAttributeDataInternal(
            model.Id.Value,
            model.IsArray,
            model.SystemName.Value,
            model.DisplayName.Value,
            model.RegistryRolesIds.Select(x => x.Value).ToArray(),
            model.DocumentRoleIds.Select(x => x.Value).ToArray());

        DocumentSystemAttributeInternal result = model.TypeSettings switch
        {
            NumberTypeSettings n => new NumberDocumentSystemAttributeInternal(data, n.Precision),
            BooleanTypeSettings => new BooleanDocumentSystemAttributeInternal(data),
            DateTypeSettings => new DateDocumentSystemAttributeInternal(data),
            ReferenceTypeSettings r => new ReferenceDocumentSystemAttributeInternal(data, r.Value),
            StringTypeSettings => new StringDocumentSystemAttributeInternal(data),
            AttachmentTypeSettings => new AttachmentDocumentSystemAttributeInternal(data),
            _ => throw new ArgumentTypeOutOfRangeException(nameof(model))
        };

        return result;
    }
}
