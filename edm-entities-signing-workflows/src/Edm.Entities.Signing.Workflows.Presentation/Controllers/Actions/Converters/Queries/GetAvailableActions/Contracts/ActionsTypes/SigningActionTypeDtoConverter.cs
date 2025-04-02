using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts.Contracts.ActionsTypes;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions.Converters.Queries.GetAvailableActions.Contracts.ActionsTypes;

internal static class SigningActionTypeDtoConverter
{
    internal static SigningActionTypeDto FromInternal(SigningActionTypeInternal action)
    {
        SigningActionTypeDto result = action switch
        {
            SigningActionTypeInternal.Cancel => SigningActionTypeDto.Cancel,
            SigningActionTypeInternal.PutIntoEffect => SigningActionTypeDto.PutIntoEffect,
            SigningActionTypeInternal.ReturnToRework => SigningActionTypeDto.ReturnToRework,
            SigningActionTypeInternal.SendToContractor => SigningActionTypeDto.SendToContractor,
            SigningActionTypeInternal.Sign => SigningActionTypeDto.Sign,
            SigningActionTypeInternal.WithdrawByContractor => SigningActionTypeDto.WithdrawByContractor,
            SigningActionTypeInternal.WithdrawBySelf => SigningActionTypeDto.WithdrawBySelf,
            _ => throw new ArgumentTypeOutOfRangeException(action)
        };

        return result;
    }
}
