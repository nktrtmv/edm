using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries.Factories;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Summaries;

internal static class SigningElectronicSummaryDbConverter
{
    internal static SigningElectronicSummaryDb FromDomain(SigningElectronicSummary summary)
    {
        Timestamp entityDate = UtcDateTimeConverterTo.ToTimeStamp(summary.EntityDate);

        var result = new SigningElectronicSummaryDb
        {
            EntityName = summary.EntityName,
            EntityNumber = summary.EntityNumber,
            EntityDate = entityDate
        };

        return result;
    }

    internal static SigningElectronicSummary ToDomain(SigningElectronicSummaryDb summary)
    {
        UtcDateTime<Entity> entityDate = UtcDateTimeConverterFrom<Entity>.FromTimestamp(summary.EntityDate);

        SigningElectronicSummary result =
            SigningElectronicSummaryFactory.CreateFromDb(summary.EntityName, summary.EntityNumber, entityDate);

        return result;
    }
}
