using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Results;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.AttributesValues;

internal static class AttributesValuesValidator
{
    internal static void Validate(DocumentUpdateParameters parameters, Document document)
    {
        DocumentAttributeValue[] attributesValues = parameters.AttributesChange?.UpdatedValues ?? document.AttributesValues;

        Id<DocumentStatus> changedStatusId = parameters.StatusChange?.Transition.To.Id ?? document.Status.Id;

        var validateParameters = new DocumentValidateParameters(document, changedStatusId, attributesValues);

        DocumentValidatorValidationResult[] validationResults = DocumentValidatorByValidators.GetValidationResults(validateParameters);

        DocumentValidatorValidationResult[] failedConditions = validationResults
            .Where(r => r.IsFailed())
            .ToArray();

        if (failedConditions.Length != 0)
        {
            string failedConditionsString = string.Join<DocumentValidatorValidationResult>(", ", failedConditions);

            throw new BusinessLogicApplicationException(
                $"""
                 Validation is not passed.
                 FailedConditions: {failedConditionsString}
                 """);
        }
    }
}
