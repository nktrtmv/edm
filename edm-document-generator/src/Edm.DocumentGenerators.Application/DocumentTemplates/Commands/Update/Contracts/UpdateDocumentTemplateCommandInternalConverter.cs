using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts;

internal static class UpdateDocumentTemplateCommandInternalConverter
{
    internal static DocumentTemplateUpdateParameters ToUpdateParameters(UpdateDocumentTemplateCommandInternal request, DocumentTemplate template)
    {
        DocumentPrototype? documentPrototype = DocumentPrototypeInternalConverter.ToDomain(request.Template.DocumentPrototype);

        Metadata<Front> frontMetadata = MetadataConverterFrom<Front>.From(request.Template.FrontMetadata);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);
        DocumentTemplateName name = DocumentTemplateName.Parse(request.Template.Name);
        SystemName? systemName = string.IsNullOrWhiteSpace(request.Template.SystemName)
            ? null
            : SystemName.Parse(request.Template.SystemName);

        DocumentTemplateUpdateParameters? result = DocumentTemplateUpdateParametersFactory.Create(
            template,
            name,
            systemName,
            request.Template.Status,
            documentPrototype,
            frontMetadata,
            currentUserId);

        return result;
    }
}
