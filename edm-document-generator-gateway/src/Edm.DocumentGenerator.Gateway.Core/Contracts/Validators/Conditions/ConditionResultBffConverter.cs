using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions;

public static class ConditionResultBffConverter
{
    public static ConditionResultBff ToBff(ConditionResultDto conditionResult)
    {
        var result = new ConditionResultBff
        {
            ConditionId = conditionResult.ConditionId,
            FailedAttributeIds = conditionResult.FailedDocumentAttributeIds.ToArray(),
            ShouldBeEmptyAttributeIds = conditionResult.ShouldBeEmptyAttributeIds.ToArray()
        };

        return result;
    }
}
