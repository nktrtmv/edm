using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators.ValueObjects.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Results;

public sealed class DocumentValidatorValidationResult
{
    public DocumentValidatorValidationResult(Id<DocumentValidator> validatorId, ConditionResult[] conditionResults)
    {
        ConditionResults = conditionResults;
        ValidatorId = validatorId;
    }

    public Id<DocumentValidator> ValidatorId { get; }
    public ConditionResult[] ConditionResults { get; }

    public bool IsFailed()
    {
        return ConditionResults.Any(p => p.IsFailed());
    }

    public override string ToString()
    {
        string conditionResults = string.Join<ConditionResult>(", ", ConditionResults);

        var result = $"{{ ValidatorId: {ValidatorId}, ConditionResults: {conditionResults} }}";

        return result;
    }
}
