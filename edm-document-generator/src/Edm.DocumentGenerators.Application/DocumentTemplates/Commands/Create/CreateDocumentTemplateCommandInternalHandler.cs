using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Create.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Create;

[UsedImplicitly]
internal sealed class CreateDocumentTemplateCommandInternalHandler(DocumentsTemplatesFacade templatesFacade) : IRequestHandler<CreateDocumentTemplateCommandInternal>
{
    public async Task Handle(CreateDocumentTemplateCommandInternal request, CancellationToken cancellationToken)
    {
        Id<DocumentTemplate> templateId = IdConverterFrom<DocumentTemplate>.FromString(request.TemplateId);

        Id<User> currentUserId = IdConverterFrom<User>.FromString(request.CurrentUser);

        DomainId domainId = DomainId.Parse(request.DomainId);
        DocumentTemplateName name = DocumentTemplateName.Parse(request.Name);
        SystemName? systemName = string.IsNullOrWhiteSpace(request.SystemName)
            ? null
            : SystemName.Parse(request.SystemName);
        DocumentTemplate? template = DocumentTemplateFactory.CreateNew(domainId, templateId, name, systemName, currentUserId);

        await templatesFacade.Upsert(template, cancellationToken);
    }
}
