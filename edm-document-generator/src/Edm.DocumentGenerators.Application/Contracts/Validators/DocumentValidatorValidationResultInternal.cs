using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators;

public sealed class DocumentValidatorValidationResultInternal
{
    public required Id<DocumentValidatorInternal> ValidatorId { get; init; }
    public required ConditionResultInternal[] ConditionResults { get; init; }
}
