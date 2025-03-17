using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Detectors.Signing;

internal static class SigningWorkflowAvailableActionsDetector
{
    internal static DocumentWorkflowSigningActionsBff? Detect(DocumentAvailableActions context, DocumentDetailedDto document)
    {
        if (context.Signing is null)
        {
            return null;
        }

        var validateStatusTransition =
            document.AvailableStatusesTransitions.Single(t => t.Type == DocumentStatusTransitionTypeDto.SigningToSigned);

        var validateStatusId = validateStatusTransition.Status.Id;

        DocumentWorkflowSigningActionBff[] actions =
            context.Signing.Actions.Select(a => DocumentWorkflowSigningActionBffConverter.FromExternal(a, validateStatusId)).ToArray();

        var result = new DocumentWorkflowSigningActionsBff
        {
            WorkflowId = context.Signing.WorkflowId,
            Actions = actions
        };

        return result;
    }
}
