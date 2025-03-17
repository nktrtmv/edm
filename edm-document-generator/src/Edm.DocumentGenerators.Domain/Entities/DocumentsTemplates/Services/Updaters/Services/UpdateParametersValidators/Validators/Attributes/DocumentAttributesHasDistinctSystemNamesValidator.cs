using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Attributes;

internal static class DocumentAttributesHasDistinctSystemNamesValidator
{
    internal static void Validate(DocumentAttribute[] attributes)
    {
        var visitedAttributesSystemNames = new HashSet<SystemName>();

        foreach (DocumentAttribute attribute in attributes)
        {
            if (attribute.SystemName == null)
            {
                continue;
            }

            if (!visitedAttributesSystemNames.Add(attribute.SystemName.Value))
            {
                throw new BusinessLogicApplicationException(
                    $"Duplicated attribute system name detected (systemName: {attribute.SystemName}, attributeId: {attribute.Id}).");
            }
        }
    }
}
