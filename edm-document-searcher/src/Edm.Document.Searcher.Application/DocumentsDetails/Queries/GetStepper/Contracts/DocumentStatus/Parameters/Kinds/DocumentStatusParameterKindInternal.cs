namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Kinds;

public enum DocumentStatusParameterKindInternal
{
    None = 0,
    ApprovalGraphTag = 1,
    ApprovalExitApprovedWithRemarkIsOff = 3,
    StageOwner = 4,
    SetCurrentUserToAttribute = 5,
    IsBacklog = 6,
    BusinessErrorHandlingStatus = 7,
    Watchers = 9,
    UnifiedNextAutoStatus = 12
}
