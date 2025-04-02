using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Documents.States.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails.Contracts.Electronics.Documents.States;

internal static class SigningDocumentStateDtoConverter
{
    internal static SigningDocumentStateDto FromInternal(SigningDocumentStateInternal state)
    {
        SigningDocumentStatusDto status = SigningDocumentStatusDtoConverter.FromInternal(state.Status);

        Timestamp statusChangedAt = UtcDateTimeConverterTo.ToTimeStamp(state.StatusChangedAt);

        var result = new SigningDocumentStateDto
        {
            Status = status,
            StatusDescription = state.StatusDescription,
            StatusChangedAt = statusChangedAt
        };

        return result;
    }
}
