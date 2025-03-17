using Edm.Entities.Signing.Workflows.ExternalServices.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Summaries;

public sealed class SigningEdxSummaryExternal
{
    public SigningEdxSummaryExternal(string name, string number, UtcDateTime<EntityExternal> entityDate)
    {
        Name = name;
        Number = number;
        EntityDate = entityDate;
    }

    public string Name { get; }
    public string Number { get; }
    public UtcDateTime<EntityExternal> EntityDate { get; }
}
