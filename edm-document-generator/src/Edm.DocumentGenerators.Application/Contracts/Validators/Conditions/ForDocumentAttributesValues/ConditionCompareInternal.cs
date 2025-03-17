using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues.ValueObjects;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues;

public sealed class ConditionCompareInternal : ConditionBaseInternal
{
    public ConditionCompareInternal(ConditionDataInternal data, ConditionCompareTypeInternal conditionCompareType) : base(data)
    {
        ConditionCompareType = conditionCompareType;
    }

    public ConditionCompareTypeInternal ConditionCompareType { get; }
}
