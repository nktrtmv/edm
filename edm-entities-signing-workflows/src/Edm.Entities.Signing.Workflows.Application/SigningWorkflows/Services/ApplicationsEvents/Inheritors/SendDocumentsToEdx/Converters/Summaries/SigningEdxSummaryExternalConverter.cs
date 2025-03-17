using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Summaries;
using Edm.Entities.Signing.Workflows.ExternalServices.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters.Summaries;

internal static class SigningEdxSummaryExternalConverter
{
    internal static SigningEdxSummaryExternal FromDomain(SigningElectronicSummary summary)
    {
        UtcDateTime<EntityExternal> date = UtcDateTimeConverterFrom<EntityExternal>.From(summary.EntityDate);

        var result = new SigningEdxSummaryExternal(summary.EntityName, summary.EntityNumber, date);

        return result;
    }
}
