using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Results;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators;

internal static class DocumentValidationResultInternalConverter
{
    internal static DocumentValidatorValidationResultInternal FromDomain(DocumentValidatorValidationResult validatorValidationResult)
    {
        Id<DocumentValidatorInternal> validatorId = IdConverterFrom<DocumentValidatorInternal>.From(validatorValidationResult.ValidatorId);

        ConditionResultInternal[] conditionResultsInternal = validatorValidationResult.ConditionResults
            .Select(ConditionResultInternalConverter.ToInternal)
            .ToArray();

        var result = new DocumentValidatorValidationResultInternal
        {
            ValidatorId = validatorId,
            ConditionResults = conditionResultsInternal
        };

        return result;
    }
}
