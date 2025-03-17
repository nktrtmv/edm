using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Targets.Generics.SingleValue;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;

public sealed class PersonBffEnricherTarget : SingleValueEnricherTargetGeneric<string, ApprovalReferenceValueExternal>
{
    internal PersonBffEnricherTarget(PersonBff target)
    {
        Target = target;
    }

    private PersonBff Target { get; }

    protected override string GetKey()
    {
        return Target.Id;
    }

    protected override void EnrichTarget(ApprovalReferenceValueExternal value)
    {
        Target.MainInfo = value.DisplayValue;
        Target.AdditionalInfo = value.DisplaySubValue;
    }
}
