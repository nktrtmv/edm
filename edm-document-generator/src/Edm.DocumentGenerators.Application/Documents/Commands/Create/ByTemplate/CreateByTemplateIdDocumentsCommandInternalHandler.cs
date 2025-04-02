using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByTemplate.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.Services.Creators;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByTemplate;

[UsedImplicitly]
internal sealed class CreateByTemplateIdDocumentsCommandInternalHandler(
    DocumentsCreatorService creator,
    IDocumentsTemplatesRepository documentsTemplatesRepository)
    : IRequestHandler<CreateDocumentByTemplateIdCommandInternal, CreateDocumentByTemplateIdCommandInternalResponse>,
        IRequestHandler<CreateDocumentByTemplateSystemNameCommandInternal, CreateDocumentByTemplateSystemNameCommandInternalResponse>
{
    public async Task<CreateDocumentByTemplateIdCommandInternalResponse> Handle(CreateDocumentByTemplateIdCommandInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);

        Id<DocumentTemplate>? templateId = IdConverterFrom<DocumentTemplate>.FromString(request.TemplateId);
        Id<User> currentUserId = IdConverterFrom<User>.FromString(request.CurrentUserId);
        Id<DocumentInternal> documentId = await creator.Create(domainId, templateId, currentUserId, null, cancellationToken);

        var response = new CreateDocumentByTemplateIdCommandInternalResponse(documentId.Value);

        return response;
    }

    public async Task<CreateDocumentByTemplateSystemNameCommandInternalResponse> Handle(
        CreateDocumentByTemplateSystemNameCommandInternal request,
        CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        SystemName systemName = SystemName.Parse(request.SystemName);
        DocumentTemplate? template = await documentsTemplatesRepository.GetRequired(domainId, systemName, cancellationToken);

        var newRequest = new CreateDocumentByTemplateIdCommandInternal(
            template.DomainId.Value,
            template.Id.Value,
            request.CurrentUserId);

        CreateDocumentByTemplateIdCommandInternalResponse? response = await Handle(newRequest, cancellationToken);
        var result = new CreateDocumentByTemplateSystemNameCommandInternalResponse(response.DocumentId);

        return result;
    }
}
