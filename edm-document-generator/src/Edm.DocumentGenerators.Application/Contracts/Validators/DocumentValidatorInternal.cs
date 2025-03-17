using Edm.DocumentGenerators.Application.Contracts.Validators.Conditions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Validators;

public sealed class DocumentValidatorInternal
{
    public DocumentValidatorInternal(Id<DocumentValidatorInternal> id, ConditionBaseInternal[] conditions, string name)
    {
        Conditions = conditions;
        Id = id;
        Name = name;
    }

    public Id<DocumentValidatorInternal> Id { get; }
    public ConditionBaseInternal[] Conditions { get; }
    public string Name { get; }
}
