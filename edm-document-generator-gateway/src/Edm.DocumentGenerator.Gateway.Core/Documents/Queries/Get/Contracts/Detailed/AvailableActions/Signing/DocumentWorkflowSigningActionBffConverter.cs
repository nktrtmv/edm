using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing.Kinds;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions.Actions.Kinds;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing;

internal static class DocumentWorkflowSigningActionBffConverter
{
    internal static DocumentWorkflowSigningActionBff FromExternal(SigningWorkflowActionKindExternal kind, string manualExitSigningStatusId)
    {
        var kindBff = DocumentWorkflowSigningActionKindBffConverter.FromExternal(kind);

        if (kindBff == DocumentWorkflowSigningActionKindBff.PutIntoEffect)
        {
            return new DocumentWorkflowSigningActionBff
            {
                Kind = kindBff,
                ValidateStatusId = manualExitSigningStatusId
            };
        }

        var result = new DocumentWorkflowSigningActionBff
        {
            Kind = kindBff
        };

        return result;
    }
}
