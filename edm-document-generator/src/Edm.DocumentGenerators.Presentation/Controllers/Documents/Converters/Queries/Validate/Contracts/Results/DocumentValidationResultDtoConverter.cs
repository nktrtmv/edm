using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Validators;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Results;

public static class DocumentValidationResultDtoConverter
{
    public static DocumentValidatorValidationResultDto FromInternal(DocumentValidatorValidationResultInternal conditionResult)
    {
        ConditionResultDto[] conditionResults = conditionResult.ConditionResults
            .Select(ConditionResultDtoConverter.FromInternal)
            .ToArray();

        var result = new DocumentValidatorValidationResultDto
        {
            ValidatorId = IdConverterTo.ToString(conditionResult.ValidatorId),
            ConditionResults = { conditionResults }
        };

        return result;
    }
}
