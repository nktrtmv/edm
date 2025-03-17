using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Actions.Queries.GetAvailableActions.Contracts.Contracts.ActionsTypes;

internal static class SigningActionTypeInternalConverter
{
    internal static SigningActionTypeInternal FromDomain(SigningActionType action)
    {
        SigningActionTypeInternal result = action switch
        {
            SigningActionType.Cancel => SigningActionTypeInternal.Cancel,
            SigningActionType.PutIntoEffect => SigningActionTypeInternal.PutIntoEffect,
            SigningActionType.ReturnToRework => SigningActionTypeInternal.ReturnToRework,
            SigningActionType.SendToContractor => SigningActionTypeInternal.SendToContractor,
            SigningActionType.Sign => SigningActionTypeInternal.Sign,
            SigningActionType.WithdrawByContractor => SigningActionTypeInternal.WithdrawByContractor,
            SigningActionType.WithdrawBySelf => SigningActionTypeInternal.WithdrawBySelf,
            _ => throw new ArgumentTypeOutOfRangeException(action)
        };

        return result;
    }
}
