using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains;
using Edm.Document.Classifier.Application.DocumentRoles.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Queries.GetAllDocumentsAttributes.Converters.DocumentsAttributes;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers;

public sealed class DocumentRolesController(IMediator mediator) : DocumentRolesService.DocumentRolesServiceBase
{
    public override async Task<GetAllDocumentRoles.Types.Response> GetAll(GetAllDocumentRoles.Types.Request request, ServerCallContext context)
    {
        var requestInternal = new GetAllDocumentRolesRequestInternal(request.DomainId);

        GetAllDocumentRolesResponseInternal response = await mediator.Send(requestInternal, context.CancellationToken);

        var items = response.Roles
            .SelectMany(role => role.AllowedAttributesConditions.Select(condition => (condition, role)))
            .GroupBy(x => x.condition)
            .Select(ToResponseItem)
            .ToList();

        var result = new GetAllDocumentRoles.Types.Response
        {
            Items = { items }
        };

        return result;
    }

    private static GetAllDocumentRoles.Types.ResponseItem ToResponseItem(
        IGrouping<AllowedAttributeConditionInternal, (AllowedAttributeConditionInternal condition, DocumentDomainDocumentRoleInternal role)> group)
    {
        AllowedAttributeConditionInternal condition = group.Key;

        DocumentAttributeTypeDto attributeDto = DocumentAttributeDocumentRegistryRolesInternalConverter.ToAttributeType(condition);
        var roles = group.Select(
                x => new GetAllDocumentRoles.Types.DocumentRole
                {
                    Display = x.role.Display,
                    Id = x.role.Id,
                    Name = x.role.Name
                })
            .ToList();

        var result = new GetAllDocumentRoles.Types.ResponseItem
        {
            Attribute = attributeDto,
            Roles = { roles }
        };

        return result;
    }
}
