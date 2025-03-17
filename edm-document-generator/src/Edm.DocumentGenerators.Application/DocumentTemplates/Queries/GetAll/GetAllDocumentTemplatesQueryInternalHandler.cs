using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.QueryParams;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.Slim;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllDocumentTemplatesQueryInternalHandler(DocumentsTemplatesFacade templatesFacade)
    : IRequestHandler<GetAllDocumentTemplatesQueryInternal, GetAllDocumentTemplatesQueryInternalResponse>
{
    public async Task<GetAllDocumentTemplatesQueryInternalResponse> Handle(GetAllDocumentTemplatesQueryInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        GetAllDocumentsTemplatesQueryParams queryParams = GetAllDocumentsTemplatesQueryParamsInternalConverter.ToDomain(request.QueryParams);

        DocumentTemplate[] templates = await templatesFacade.GetAll(domainId, queryParams, cancellationToken);

        DocumentTemplateSlimInternal[] templatesInternal = templates.Select(DocumentTemplateSlimInternalConverter.FromDomain).ToArray();

        var result = new GetAllDocumentTemplatesQueryInternalResponse(templatesInternal);

        return result;
    }
}
