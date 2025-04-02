using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;

public sealed record DocumentAttributesChange(DocumentAttributeValue[] OriginalValues, DocumentAttributeValue[] UpdatedValues)
{
    public override string ToString()
    {
        string? updatedValues = string.Join<DocumentAttributeValue>(", ", UpdatedValues);

        return $"{{ UpdatedValues: {updatedValues} }}";
    }
}
