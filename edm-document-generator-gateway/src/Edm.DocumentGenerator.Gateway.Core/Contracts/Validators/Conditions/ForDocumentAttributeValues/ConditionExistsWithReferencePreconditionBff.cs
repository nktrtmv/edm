using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ForDocumentAttributeValues;

public sealed class ConditionExistsWithReferencePreconditionBff : ConditionBaseBff
{
    public ConditionExistsWithReferencePreconditionBff(ConditionDataBff data, string preconditionReferenceId) : base(data)
    {
        PreconditionReferenceId = preconditionReferenceId;
    }

    public string PreconditionReferenceId { get; }
}
