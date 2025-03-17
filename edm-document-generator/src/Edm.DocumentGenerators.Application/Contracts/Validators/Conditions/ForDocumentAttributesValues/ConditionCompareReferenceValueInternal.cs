using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues.ValueObjects;
using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues;

public sealed class ConditionCompareReferenceValueInternal(ConditionDataInternal data, ConditionCompareReferenceValueTypeInternal conditionCompareType)
    : ConditionBaseInternal(data)
{
    public ConditionCompareReferenceValueTypeInternal ConditionCompareType { get; } = conditionCompareType;
}
