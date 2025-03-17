using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions.Actions.Kinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing.Kinds;

internal static class DocumentWorkflowSigningActionKindBffConverter
{
    internal static DocumentWorkflowSigningActionKindBff FromExternal(SigningWorkflowActionKindExternal kind)
    {
        var result = kind switch
        {
            SigningWorkflowActionKindExternal.Cancel => DocumentWorkflowSigningActionKindBff.Cancel,
            SigningWorkflowActionKindExternal.PutIntoEffect => DocumentWorkflowSigningActionKindBff.PutIntoEffect,
            SigningWorkflowActionKindExternal.ReturnToRework => DocumentWorkflowSigningActionKindBff.ReturnToRework,
            SigningWorkflowActionKindExternal.SendToContractor => DocumentWorkflowSigningActionKindBff.SendToContractor,
            SigningWorkflowActionKindExternal.Sign => DocumentWorkflowSigningActionKindBff.Sign,
            SigningWorkflowActionKindExternal.WithdrawByContractor => DocumentWorkflowSigningActionKindBff.WithdrawByContractor,
            SigningWorkflowActionKindExternal.WithdrawBySelf => DocumentWorkflowSigningActionKindBff.WithdrawBySelf,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
