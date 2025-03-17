using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.AttributesChanges;

internal static class DocumentAttributesChangeConverter
{
    internal static DocumentAttributesChange FromInternal(DocumentUpdateParametersInternal parameters, Document document)
    {
        DocumentAttribute[] attributes = document.AttributesValues.Select(p => p.Attribute).ToArray();

        DocumentAttributeValue[] updatedValues =
            DocumentAttributeValueBareInternalToDomainConverter.ToDomain(parameters.AttributesValues, attributes).ToArray();

        var result = new DocumentAttributesChange(document.AttributesValues, updatedValues);

        return result;
    }

    internal static DocumentAttributesChange FromInternal(DocumentValidateParametersInternal parameters, Document document)
    {
        DocumentAttribute[] attributes = document.AttributesValues.Select(p => p.Attribute).ToArray();

        DocumentAttributeValue[] updatedValues =
            DocumentAttributeValueBareInternalToDomainConverter.ToDomain(parameters.AttributesValues, attributes).ToArray();

        var result = new DocumentAttributesChange(document.AttributesValues, updatedValues);

        return result;
    }
}
