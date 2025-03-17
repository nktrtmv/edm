namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;

public enum DocumentStatusTransitionTypeTemplateBff
{
    None = 0,
    Manual = 1,
    ApprovalToApproved = 2,
    ApprovalToCancelled = 3,
    ApprovalToRework = 4,
    ApprovalToApprovedWithRemark = 5,
    SigningToSigned = 6,
    SigningToCancelled = 7,
    SigningToPreparation = 8,
    SigningToRework = 9
}
