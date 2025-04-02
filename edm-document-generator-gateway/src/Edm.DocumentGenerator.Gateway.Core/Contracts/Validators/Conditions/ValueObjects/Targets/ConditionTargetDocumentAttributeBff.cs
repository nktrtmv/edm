namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets;

public sealed class ConditionTargetDocumentAttributeBff : ConditionTargetBff
{
    public required string DocumentAttributeId { get; init; }
}
