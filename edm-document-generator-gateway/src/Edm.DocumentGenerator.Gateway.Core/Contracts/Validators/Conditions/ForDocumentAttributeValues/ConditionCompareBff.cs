using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ForDocumentAttributeValues.ValueObjects;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ForDocumentAttributeValues;

public sealed class ConditionCompareBff : ConditionBaseBff
{
    public ConditionCompareBff(ConditionDataBff data, ConditionCompareTypeBff conditionCompareType) : base(data)
    {
        ConditionCompareType = conditionCompareType;
    }

    public ConditionCompareTypeBff ConditionCompareType { get; }
}
