namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions;

public sealed class ConditionResultBff
{
    public required string ConditionId { get; init; }

    public required string[] FailedAttributeIds { get; init; }

    public required string[] ShouldBeEmptyAttributeIds { get; init; }
}
