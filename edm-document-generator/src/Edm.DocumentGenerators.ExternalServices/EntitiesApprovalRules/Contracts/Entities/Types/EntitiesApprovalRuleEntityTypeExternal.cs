using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types;

public sealed class EntitiesApprovalRuleEntityTypeExternal
{
    public EntitiesApprovalRuleEntityTypeExternal(EntitiesApprovalRuleEntityTypeKeyExternal key, DocumentAttribute[] attributes, string name)
    {
        Key = key;
        Attributes = attributes;
        Name = name;
    }

    public EntitiesApprovalRuleEntityTypeKeyExternal Key { get; }
    public DocumentAttribute[] Attributes { get; }
    public string Name { get; }
}
