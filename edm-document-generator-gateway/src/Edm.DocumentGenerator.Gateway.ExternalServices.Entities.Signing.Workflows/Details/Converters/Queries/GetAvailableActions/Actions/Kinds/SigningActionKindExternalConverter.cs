using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts.Actions.Kinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions.Actions.Kinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetAvailableActions.Actions.Kinds;

internal static class SigningActionKindExternalConverter
{
    internal static SigningWorkflowActionKindExternal FromDto(SigningWorkflowActionKindDto type)
    {
        var result = type switch
        {
            SigningWorkflowActionKindDto.Cancel => SigningWorkflowActionKindExternal.Cancel,
            SigningWorkflowActionKindDto.PutIntoEffect => SigningWorkflowActionKindExternal.PutIntoEffect,
            SigningWorkflowActionKindDto.ReturnToRework => SigningWorkflowActionKindExternal.ReturnToRework,
            SigningWorkflowActionKindDto.SendToContractor => SigningWorkflowActionKindExternal.SendToContractor,
            SigningWorkflowActionKindDto.Sign => SigningWorkflowActionKindExternal.Sign,
            SigningWorkflowActionKindDto.WithdrawByContractor => SigningWorkflowActionKindExternal.WithdrawByContractor,
            SigningWorkflowActionKindDto.WithdrawBySelf => SigningWorkflowActionKindExternal.WithdrawBySelf,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
