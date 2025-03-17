using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ForDocumentAttributeValues.ValueObjects;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ForDocumentAttributeValues;

public sealed class ConditionCompareReferenceBff(ConditionDataBff data, ConditionCompareReferenceTypeBff conditionCompareReferenceType)
    : ConditionBaseBff(data)
{
    public ConditionCompareReferenceTypeBff ConditionCompareReferenceType { get; } = conditionCompareReferenceType;
}
