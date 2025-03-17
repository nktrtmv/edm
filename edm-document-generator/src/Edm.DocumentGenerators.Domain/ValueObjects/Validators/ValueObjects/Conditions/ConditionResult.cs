using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;

public sealed class ConditionResult
{
    private ConditionResult(Id<ICondition> conditionId, Id<DocumentAttribute>[] failedAttributes, Id<DocumentAttribute>[] shouldBeEmptyAttributesId)
    {
        ConditionId = conditionId;
        FailedAttributesId = failedAttributes ?? throw new ArgumentNullException(nameof(failedAttributes));
        ShouldBeEmptyAttributesId = shouldBeEmptyAttributesId;
    }

    public Id<ICondition> ConditionId { get; }
    public Id<DocumentAttribute>[] FailedAttributesId { get; }
    public Id<DocumentAttribute>[] ShouldBeEmptyAttributesId { get; }

    public bool IsFailed()
    {
        return FailedAttributesId.Any();
    }

    public static ConditionResult Succeed(Id<ICondition> conditionId)
    {
        return new ConditionResult(conditionId, Array.Empty<Id<DocumentAttribute>>(), Array.Empty<Id<DocumentAttribute>>());
    }

    public static ConditionResult Create(Id<ICondition> conditionId, Id<DocumentAttribute>[] failedAttributes)
    {
        return new ConditionResult(conditionId, failedAttributes, Array.Empty<Id<DocumentAttribute>>());
    }

    public static ConditionResult Create(Id<ICondition> conditionId, Id<DocumentAttribute>[] failedAttributes, Id<DocumentAttribute>[] shouldBeEmptyAttributes)
    {
        return new ConditionResult(conditionId, failedAttributes, shouldBeEmptyAttributes);
    }

    public override string ToString()
    {
        string failedAttributesId = string.Join<Id<DocumentAttribute>>(", ", FailedAttributesId);

        string shouldBeEmptyAttributesId = string.Join<Id<DocumentAttribute>>(", ", ShouldBeEmptyAttributesId);

        var result = $"{{ ConditionId: {ConditionId}, FailedAttributesId: {failedAttributesId}, ShouldBeEmptyAttributesId: {shouldBeEmptyAttributesId} }}";

        return result;
    }
}
