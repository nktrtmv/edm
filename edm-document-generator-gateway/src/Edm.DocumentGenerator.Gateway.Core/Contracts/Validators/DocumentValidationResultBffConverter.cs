using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators;

public static class DocumentValidationResultBffConverter
{
    public static DocumentValidationResultBff ToBff(DocumentValidatorValidationResultDto validationResult)
    {
        ConditionResultBff[] conditionsResults = validationResult.ConditionResults
            .Select(ConditionResultBffConverter.ToBff)
            .ToArray();

        var result = new DocumentValidationResultBff
        {
            ValidatorId = validationResult.ValidatorId,
            ConditionsResults = conditionsResults
        };

        return result;
    }
}
