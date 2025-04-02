using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Stages.ValueObjects.Parties.Types;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Parties;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Parties.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters.Parties;

internal static class SigningEdxPartiesExternalConverter
{
    internal static SigningEdxPartiesExternal FromDomain(SigningState state)
    {
        Id<CompanyExternal> contractorId = GetParty(state.Stages, SigningPartyType.Contractor);

        Id<CompanyExternal> selfId = GetParty(state.Stages, SigningPartyType.Self);

        var result = new SigningEdxPartiesExternal(contractorId, selfId);

        return result;
    }

    private static Id<CompanyExternal> GetParty(SigningStage[] stages, SigningPartyType type)
    {
        SigningStage stage = stages.Single(s => s.Party.Type == type);

        Id<CompanyExternal> result = IdConverterFrom<CompanyExternal>.From(stage.Party.CompanyId);

        return result;
    }
}
