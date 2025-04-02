using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions.ValueObjects;

namespace Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;

public class ConditionBaseInternal
{
    internal ConditionBaseInternal(ConditionDataInternal data)
    {
        Data = data;
    }

    public ConditionDataInternal Data { get; }
}
