using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States.Statuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.States;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States;

internal static class SigningStageStateInternalConverter
{
    internal static SigningStageStateInternal FromDomain(SigningStageState state)
    {
        SigningStageStatusInternal status = SigningStageStatusInternalConverter.FromDomain(state.Status);

        UtcDateTime<SigningDocumentInternal> statusChangedAt = UtcDateTimeConverterFrom<SigningDocumentInternal>.From(state.StatusChangedAt);

        var result = new SigningStageStateInternal(status, statusChangedAt);

        return result;
    }
}
