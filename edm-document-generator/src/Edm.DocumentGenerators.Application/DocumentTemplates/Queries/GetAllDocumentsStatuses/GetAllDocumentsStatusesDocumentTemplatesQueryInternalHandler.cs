using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAllDocumentsStatuses.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAllDocumentsStatuses;

[UsedImplicitly]
internal sealed class GetAllDocumentsStatusesDocumentTemplatesQueryInternalHandler(DocumentsTemplatesFacade templatesFacade)
    : IRequestHandler<GetAllDocumentsStatusesDocumentTemplatesQueryInternal, GetAllDocumentsStatusesDocumentTemplatesQueryResponseInternal>
{
    public async Task<GetAllDocumentsStatusesDocumentTemplatesQueryResponseInternal> Handle(
        GetAllDocumentsStatusesDocumentTemplatesQueryInternal request,
        CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        var queryParams = GetAllDocumentsTemplatesQueryParams.Instance;

        DocumentTemplate[] templates = await templatesFacade.GetAll(domainId, queryParams, cancellationToken);

        string[] statuses = GetUniqueStatuses(templates);

        var result = new GetAllDocumentsStatusesDocumentTemplatesQueryResponseInternal(statuses);

        return result;
    }

    private static string[] GetUniqueStatuses(DocumentTemplate[] templates)
    {
        string[] result = templates
            .SelectMany(template => template.DocumentPrototype.StatusTransitions)
            .SelectMany(t => new[] { t.From.DisplayName, t.To.DisplayName })
            .Distinct()
            .ToArray();

        return result;
    }
}
