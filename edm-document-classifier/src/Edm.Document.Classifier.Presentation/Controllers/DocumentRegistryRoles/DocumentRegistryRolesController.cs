using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes.Contracts;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Queries.GetAllDocumentsAttributes;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Queries.GetAllDocumentsAttributes.Converters.DocumentsAttributes;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles;

public sealed class DocumentRegistryRolesController(IMediator mediator, ILogger<DocumentRegistryRolesController> logger)
    : DocumentRegistryRolesService.DocumentRegistryRolesServiceBase
{
    public override async Task<GetAllDomainsV2.Types.Response> GetAllDomainsV2(GetAllDomainsV2.Types.Query request, ServerCallContext context)
    {
        GetAllDomainsInternalResponse response = await mediator.Send(GetAllDomainsInternalQuery.Instance, context.CancellationToken);

        List<DomainDto> domains = response.Domains.Select(ToDto).ToList();
        var result = new GetAllDomainsV2.Types.Response { Domains = { domains } };

        return result;
    }

    public override async Task<GetDomainById.Types.Response> GetDomainById(GetDomainById.Types.Query request, ServerCallContext context)
    {
        GetAllDomainsInternalResponse response = await mediator.Send(GetAllDomainsInternalQuery.Instance, context.CancellationToken);

        DocumentDomainInternal? domain = response.Domains.FirstOrDefault(x => x.Id == request.DomainId);

        if (domain == null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, $"Domain with id {request.DomainId} wasn't found"));
        }

        DomainDto domainDto = ToDto(domain);

        var result = new GetDomainById.Types.Response { Domain = domainDto };

        return result;
    }

    public override async Task<GetDomainRegistryRoles.Types.Response> GetDomainRegistryRoles(GetDomainRegistryRoles.Types.Query request, ServerCallContext context)
    {
        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(request.DomainId);
        var query = new GetDomainRegistryRolesInternalQuery(domainId);
        GetDomainRegistryRolesInternalResponse response = await mediator.Send(query, context.CancellationToken);

        List<DocumentAttributeDocumentRegistryRolesDto> domainsRoles =
            DocumentAttributeDocumentRegistryRolesInternalConverter.ToDto(response.RegistryRoles, false).ToList();

        var result = new GetDomainRegistryRoles.Types.Response
        {
            DomainAttributesRoles = { domainsRoles }
        };

        return result;
    }

    public override Task<GetAllDocumentsAttributesDocumentRegistryRolesQueryResponse> GetAllDocumentsAttributes(
        GetAllDocumentsAttributesDocumentRegistryRolesQuery query,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            logger,
            nameof(GetAllDocumentsAttributes),
            query,
            async () =>
            {
                string domainId = DomainIdHelper.GetDomainIdOrSetDefault(query.DomainId);
                var request = new GetDomainRegistryRolesInternalQuery(domainId, true);

                GetDomainRegistryRolesInternalResponse response = await mediator.Send(request, context.CancellationToken);
                GetAllDocumentsAttributesDocumentRegistryRolesQueryResponse result =
                    GetAllDocumentsAttributesDocumentRegistryRolesQueryInternalResponseConverter.ToDto(response);

                return result;
            });
    }

    private static DomainDto ToDto(DocumentDomainInternal model)
    {
        var result = new DomainDto
        {
            DomainId = model.Id,
            DomainName = model.Name,
            DocumentCreationType = (DocumentCreationTypeDto)model.DocumentCreationType,
            DocumentsSettings = new DocumentsSettingsDto
            {
                DisableManualCreation = model.DocumentSettings.DisableManualCreation,
                CreationTitle = model.DocumentSettings.CreationTitle,
                RegistryTitle = model.DocumentSettings.RegistryTitle,
                DetailsTitle = model.DocumentSettings.DetailsTitle
            },
            CommentsSettings = new CommentsSettingsDto
            {
                EntityType = model.CommentsSettings.EntityType
            },
            UrlAlias = model.UrlAlias
        };

        return result;
    }
}
