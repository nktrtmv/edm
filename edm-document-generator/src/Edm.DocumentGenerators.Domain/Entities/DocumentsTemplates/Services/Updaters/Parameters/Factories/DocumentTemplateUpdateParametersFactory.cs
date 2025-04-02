using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters.Services.Attributes.FlatListCollectors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters.Factories;

public static class DocumentTemplateUpdateParametersFactory
{
    public static DocumentTemplateUpdateParameters Create(
        DocumentTemplate template,
        DocumentTemplateName updatedName,
        SystemName? systemName,
        DocumentTemplateStatus updatedStatus,
        DocumentPrototype updatedDocumentPrototype,
        Metadata<Front> updatedFrontMetadata,
        Id<User> currentUserId)
    {
        DocumentAttribute[] originalAttributes = template.DocumentPrototype.Attributes;

        DocumentAttribute[] updatedAttributes = updatedDocumentPrototype.Attributes;

        DocumentAttribute[] updatedAttributesFlatList = DocumentAttributesFlatListCollector.GetAll(updatedAttributes).ToArray();

        DocumentAttribute[] originalAttributesFlatList = DocumentAttributesFlatListCollector.GetAll(originalAttributes).ToArray();

        Dictionary<Id<DocumentAttribute>, DocumentAttribute> originalAttributesById = originalAttributesFlatList.ToDictionary(x => x.Id);

        var result = new DocumentTemplateUpdateParameters(
            template,
            originalAttributes,
            originalAttributesById,
            updatedName,
            systemName,
            updatedStatus,
            updatedDocumentPrototype,
            updatedAttributesFlatList,
            updatedFrontMetadata,
            currentUserId);

        return result;
    }
}
