using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Validators;

public sealed class DocumentValidatorBff
{
    public DocumentValidatorBff(string id, ConditionBaseBff[] conditions, string name)
    {
        Id = id;
        Conditions = conditions;
        Name = name;
    }

    public string Id { get; }
    public ConditionBaseBff[] Conditions { get; }
    public string Name { get; }
}
