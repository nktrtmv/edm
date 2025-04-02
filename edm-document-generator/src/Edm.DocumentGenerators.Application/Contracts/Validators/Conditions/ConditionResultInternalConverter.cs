using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;

public static class ConditionResultInternalConverter
{
    public static ConditionResultInternal ToInternal(ConditionResult conditionResult)
    {
        Id<ConditionBaseInternal> conditionId = IdConverterFrom<ConditionBaseInternal>.From(conditionResult.ConditionId);

        Id<DocumentAttributeInternal>[] failedAttributes = conditionResult.FailedAttributesId
            .Select(IdConverterFrom<DocumentAttributeInternal>.From)
            .ToArray();

        Id<DocumentAttributeInternal>[] shouldBeEmptyAttributes = conditionResult.ShouldBeEmptyAttributesId
            .Select(IdConverterFrom<DocumentAttributeInternal>.From)
            .ToArray();

        var result = new ConditionResultInternal
        {
            ConditionId = conditionId,
            FailedAttributes = failedAttributes,
            ShouldBeEmptyAttributesId = shouldBeEmptyAttributes
        };

        return result;
    }
}
