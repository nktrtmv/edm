using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries.Factories;

public static class SigningElectronicSummaryFactory
{
    public static SigningElectronicSummary CreateFrom(string entityName, string entityNumber, UtcDateTime<Entity> entityDate)
    {
        SigningElectronicSummary result = CreateFromDb(entityName, entityNumber, entityDate);

        return result;
    }

    public static SigningElectronicSummary CreateFromDb(string entityName, string entityNumber, UtcDateTime<Entity> entityDate)
    {
        var result = new SigningElectronicSummary(entityName, entityNumber, entityDate);

        return result;
    }
}
