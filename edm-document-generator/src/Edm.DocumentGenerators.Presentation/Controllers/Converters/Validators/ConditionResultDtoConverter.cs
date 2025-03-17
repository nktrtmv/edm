using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Validators;

public static class ConditionResultDtoConverter
{
    public static ConditionResultDto FromInternal(ConditionResultInternal conditionResult)
    {
        string[] failedAttributes = conditionResult.FailedAttributes
            .Select(IdConverterTo.ToString)
            .ToArray();

        string[] shouldBeEmptyAttributes = conditionResult.ShouldBeEmptyAttributesId
            .Select(IdConverterTo.ToString)
            .ToArray();

        var result = new ConditionResultDto
        {
            ConditionId = IdConverterTo.ToString(conditionResult.ConditionId),
            FailedDocumentAttributeIds = { failedAttributes },
            ShouldBeEmptyAttributeIds = { shouldBeEmptyAttributes }
        };

        return result;
    }
}
