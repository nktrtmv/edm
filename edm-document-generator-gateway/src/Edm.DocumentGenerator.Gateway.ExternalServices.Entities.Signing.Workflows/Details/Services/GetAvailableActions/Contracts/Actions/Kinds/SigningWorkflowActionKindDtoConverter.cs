using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions.Contracts.Actions.Kinds;

internal static class SigningWorkflowActionKindDtoConverter
{
    internal static SigningWorkflowActionKindDto FromDto(SigningActionTypeDto type)
    {
        var result = type switch
        {
            SigningActionTypeDto.Cancel => SigningWorkflowActionKindDto.Cancel,
            SigningActionTypeDto.PutIntoEffect => SigningWorkflowActionKindDto.PutIntoEffect,
            SigningActionTypeDto.ReturnToRework => SigningWorkflowActionKindDto.ReturnToRework,
            SigningActionTypeDto.SendToContractor => SigningWorkflowActionKindDto.SendToContractor,
            SigningActionTypeDto.Sign => SigningWorkflowActionKindDto.Sign,
            SigningActionTypeDto.WithdrawByContractor => SigningWorkflowActionKindDto.WithdrawByContractor,
            SigningActionTypeDto.WithdrawBySelf => SigningWorkflowActionKindDto.WithdrawBySelf,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
