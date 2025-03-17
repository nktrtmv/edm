using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects;

internal static class ConditionDataBffConverter
{
    internal static ConditionDataBff ToBff(ConditionDataDto conditionSignature)
    {
        var target = ConditionTargetBffConverter.ToBff(conditionSignature.ConditionTarget);

        var signature = new ConditionDataBff(
            conditionSignature.ConditionId,
            conditionSignature.LinkedDocumentAttributeIds.ToArray(),
            target,
            conditionSignature.SupportedDocumentStatusIds.ToArray());

        return signature;
    }

    internal static ConditionDataDto FromBff(ConditionDataBff conditionData)
    {
        var target = ConditionTargetBffConverter.FromBff(conditionData.Target);

        var signature = new ConditionDataDto
        {
            ConditionId = conditionData.ConditionId,
            LinkedDocumentAttributeIds = { conditionData.LinkedDocumentAttributeIds },
            ConditionTarget = target,
            SupportedDocumentStatusIds = { conditionData.SupportedDocumentStatusIds }
        };

        return signature;
    }
}
