using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities;

public sealed class EntitiesApprovalRuleEntityExternal
{
    public EntitiesApprovalRuleEntityExternal(EntitiesApprovalRuleEntityTypeKeyExternal typeKey, DocumentAttributeValue[] attributesValues)
    {
        TypeKey = typeKey;
        AttributesValues = attributesValues;
    }

    public EntitiesApprovalRuleEntityTypeKeyExternal TypeKey { get; }
    public DocumentAttributeValue[] AttributesValues { get; }
}
