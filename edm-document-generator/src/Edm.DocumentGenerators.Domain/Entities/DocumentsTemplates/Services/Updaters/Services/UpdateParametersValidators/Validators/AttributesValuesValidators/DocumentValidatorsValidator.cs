using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Attributes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Statuses.Validators;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.AttributesValuesValidators;

internal sealed class DocumentValidatorsValidator
{
    private DocumentValidatorsValidator(
        DocumentAttributeExistsValidator attributeExistsValidator,
        DocumentStatusExistsValidator statusExistsValidator)
    {
        AttributeExistsValidator = attributeExistsValidator;
        StatusExistsValidator = statusExistsValidator;
    }

    private DocumentAttributeExistsValidator AttributeExistsValidator { get; }
    private DocumentStatusExistsValidator StatusExistsValidator { get; }

    internal static void Validate(
        DocumentValidator[] validators,
        DocumentAttributeExistsValidator attributeExistsValidator,
        DocumentStatusExistsValidator statusExistsValidator)
    {
        var validator = new DocumentValidatorsValidator(attributeExistsValidator, statusExistsValidator);

        validator.Validate(validators);
    }

    private void Validate(DocumentValidator[] validators)
    {
        foreach (DocumentValidator validator in validators)
        {
            foreach (ICondition condition in validator.Conditions)
            {
                _ = condition.Data.LinkedDocumentAttributeIds.All(AttributeExistsValidator.Validate);
                _ = condition.Data.SupportedDocumentStatusIds.All(StatusExistsValidator.Validate);
            }
        }
    }
}
