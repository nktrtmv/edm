namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

public enum DocumentStatusParameterKind
{
    None = 0,
    ApprovalGraphTag = 1,
    ApprovalExitApprovedWithRemarkIsOff = 3,
    StageOwner = 4,
    SetCurrentUserToAttribute = 5,
    IsBacklog = 6,
    BusinessErrorHandlingStatus = 7,
    UnifiedNextAutoStatus = 12,
    Watchers = 9
}
