using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators;

public sealed class DocumentValidationResultBff
{
    public required string ValidatorId { get; init; }
    public required ConditionResultBff[] ConditionsResults { get; init; }
}
