using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries;

public sealed class SigningElectronicSummary
{
    internal SigningElectronicSummary(string entityName, string entityNumber, UtcDateTime<Entity> entityDate)
    {
        EntityName = entityName;
        EntityNumber = entityNumber;
        EntityDate = entityDate;
    }

    public string EntityName { get; }
    public string EntityNumber { get; }
    public UtcDateTime<Entity> EntityDate { get; }
}
