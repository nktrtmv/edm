using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages.Contracts.Stages.States.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages.Contracts.Stages.States;

internal static class SigningStageStateDtoConverter
{
    internal static SigningStageStateDto FromInternal(SigningStageStateInternal state)
    {
        SigningStageStatusDto status = SigningStageStatusDtoConverter.FromInternal(state.Status);

        Timestamp statusChangedAt = UtcDateTimeConverterTo.ToTimeStamp(state.StatusChangedAt);

        var result = new SigningStageStateDto
        {
            Status = status,
            StatusChangedAt = statusChangedAt
        };

        return result;
    }
}
