using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Validators;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.AttributeChanges;

internal static class AttributesChangeValidator
{
    internal static void Validate(DocumentAttributesChange attributesChange)
    {
        AttributesValuesAreDistinctValidator.Validate(attributesChange.UpdatedValues);
    }
}
