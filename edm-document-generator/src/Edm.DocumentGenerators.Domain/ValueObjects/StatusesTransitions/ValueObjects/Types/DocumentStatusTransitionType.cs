namespace Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;

public enum DocumentStatusTransitionType
{
    None = 0,
    Manual = 1,
    ApprovalToApproved = 2,
    ApprovalToCancelled = 3,
    ApprovalToRework = 4,
    ApprovalToApprovedWithRemark = 5,
    SigningToSigned = 9,
    SigningToCancelled = 10,
    SigningToPreparation = 11,
    SigningToRework = 12
}
