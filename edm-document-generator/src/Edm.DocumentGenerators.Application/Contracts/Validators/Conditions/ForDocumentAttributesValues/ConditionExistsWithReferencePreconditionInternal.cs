using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ForDocumentAttributesValues;

public sealed class ConditionExistsWithReferencePreconditionInternal : ConditionBaseInternal
{
    public ConditionExistsWithReferencePreconditionInternal(ConditionDataInternal data, string preconditionReferenceId) : base(data)
    {
        PreconditionReferenceId = preconditionReferenceId;
    }

    public string PreconditionReferenceId { get; }
}
