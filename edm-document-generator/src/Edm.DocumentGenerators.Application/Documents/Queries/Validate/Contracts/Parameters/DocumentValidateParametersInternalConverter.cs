using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Parameters;

internal static class DocumentValidateParametersInternalConverter
{
    internal static DocumentValidateParameters ToDomain(DocumentValidateParametersInternal parameters, Document document)
    {
        DocumentAttribute[] attributes = document.AttributesValues.Select(p => p.Attribute).ToArray();

        DocumentAttributeValue[] attributesValues =
            DocumentAttributeValueBareInternalToDomainConverter.ToDomain(parameters.AttributesValues, attributes).ToArray();

        Id<DocumentStatus> changedStatusId = IdConverterFrom<DocumentStatus>.From(parameters.StatusId);

        var result = new DocumentValidateParameters(document, changedStatusId, attributesValues);

        return result;
    }
}
