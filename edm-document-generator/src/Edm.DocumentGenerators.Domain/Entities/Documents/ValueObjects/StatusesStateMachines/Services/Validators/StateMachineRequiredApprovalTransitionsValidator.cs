using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Boolean;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.Services.Validators;

internal sealed class StateMachineRequiredApprovalTransitionsValidator : StateMachineValidator
{
    private static readonly DocumentStatusTransitionType[] RequiredTransitionsWithRemark =
    {
        DocumentStatusTransitionType.ApprovalToCancelled,
        DocumentStatusTransitionType.ApprovalToApproved,
        DocumentStatusTransitionType.ApprovalToRework,
        DocumentStatusTransitionType.ApprovalToApprovedWithRemark
    };

    private static readonly DocumentStatusTransitionType[] RequiredTransitionsWithoutRemark =
    {
        DocumentStatusTransitionType.ApprovalToCancelled,
        DocumentStatusTransitionType.ApprovalToApproved,
        DocumentStatusTransitionType.ApprovalToRework
    };

    internal override void Validate(Dictionary<DocumentStatus, DocumentStatusTransition[]> transitionsByFromStatuses)
    {
        KeyValuePair<DocumentStatus, DocumentStatusTransition[]>[] transitionsByFromApprovalStatuses = transitionsByFromStatuses
            .Where(s => s.Key.Type == DocumentStatusType.Approval)
            .ToArray();

        foreach (KeyValuePair<DocumentStatus, DocumentStatusTransition[]> transitionsByFromApprovalStatus in transitionsByFromApprovalStatuses)
        {
            DocumentStatusTransitionType[] requiredTransitionTypes = GetRequiredTransitions(transitionsByFromApprovalStatus.Key);

            ValidateRequiredTransitions(transitionsByFromApprovalStatus.Value, requiredTransitionTypes);
        }
    }

    private static void ValidateRequiredTransitions(DocumentStatusTransition[] transitions, DocumentStatusTransitionType[] requiredTransitionTypes)
    {
        foreach (DocumentStatusTransitionType requiredTransitionType in requiredTransitionTypes)
        {
            int requiredTransitionCount = transitions.Count(t => t.Type == requiredTransitionType);

            if (requiredTransitionCount != 1)
            {
                throw new BusinessLogicApplicationException($"Approval status require outgoing transition of type: '{requiredTransitionType}').");
            }
        }
    }

    private static DocumentStatusTransitionType[] GetRequiredTransitions(DocumentStatus documentStatus)
    {
        bool approvingWithRemarkIsDisabled =
            BooleanStatusParameterDetector.IsSet(documentStatus, DocumentStatusParameterKind.ApprovalExitApprovedWithRemarkIsOff);

        DocumentStatusTransitionType[] result = approvingWithRemarkIsDisabled
            ? RequiredTransitionsWithoutRemark
            : RequiredTransitionsWithRemark;

        return result;
    }
}
