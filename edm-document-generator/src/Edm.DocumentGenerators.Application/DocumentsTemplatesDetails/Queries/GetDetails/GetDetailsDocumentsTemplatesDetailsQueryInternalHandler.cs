using Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts;
using Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts.Templates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails;

[UsedImplicitly]
internal sealed class GetDetailsDocumentsTemplatesDetailsQueryInternalHandler
    : IRequestHandler<GetDetailsDocumentsTemplatesDetailsQueryInternal, GetDetailsDocumentsTemplatesDetailsQueryInternalResponse>
{
    public GetDetailsDocumentsTemplatesDetailsQueryInternalHandler(IDocumentsTemplatesRepository templates)
    {
        Templates = templates;
    }

    private IDocumentsTemplatesRepository Templates { get; }

    public async Task<GetDetailsDocumentsTemplatesDetailsQueryInternalResponse> Handle(
        GetDetailsDocumentsTemplatesDetailsQueryInternal request,
        CancellationToken cancellationToken)
    {
        Id<DocumentTemplate>[] templatesIds = request.TemplatesIds.Select(IdConverterFrom<DocumentTemplate>.From).ToArray();
        DomainId domainId = DomainId.Parse(request.DomainId);
        DocumentTemplate[] response = await Templates.GetByIds(domainId, templatesIds, cancellationToken);

        GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternal[] templates =
            response.Select(GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternalConverter.FromDomain).ToArray();

        var result = new GetDetailsDocumentsTemplatesDetailsQueryInternalResponse(templates);

        return result;
    }
}
