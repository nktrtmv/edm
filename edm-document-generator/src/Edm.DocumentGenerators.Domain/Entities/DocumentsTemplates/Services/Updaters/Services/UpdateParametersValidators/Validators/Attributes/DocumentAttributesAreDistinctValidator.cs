using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.Attributes;

internal static class DocumentAttributesAreDistinctValidator
{
    internal static void Validate(DocumentAttribute[] attributes)
    {
        var visitedAttributeIds = new HashSet<Id<DocumentAttribute>>();

        foreach (DocumentAttribute attribute in attributes)
        {
            if (!visitedAttributeIds.Add(attribute.Id))
            {
                throw new BusinessLogicApplicationException($"Duplicated attribute detected (id {attribute.Id})");
            }
        }
    }
}
