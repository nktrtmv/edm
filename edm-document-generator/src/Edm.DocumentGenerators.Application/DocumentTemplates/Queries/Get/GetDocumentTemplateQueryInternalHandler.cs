using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentTemplateQueryInternalHandler(DocumentsTemplatesFacade templates)
    : IRequestHandler<GetDocumentTemplateQueryInternal, GetDocumentTemplateQueryInternalResponse>
{
    public async Task<GetDocumentTemplateQueryInternalResponse> Handle(GetDocumentTemplateQueryInternal request, CancellationToken cancellationToken)
    {
        Id<DocumentTemplate>? id = IdConverterFrom<DocumentTemplate>.FromString(request.Id);

        DomainId domainId = DomainId.Parse(request.DomainId);
        DocumentTemplate? template = await templates.Get(domainId, id, cancellationToken);

        if (template is null)
        {
            return new GetDocumentTemplateQueryInternalResponse(null);
        }

        DocumentTemplateDetailedInternal? templateInternal = DocumentTemplateInternalConverter.FromDomain(template);

        var result = new GetDocumentTemplateQueryInternalResponse(templateInternal);

        return result;
    }
}
