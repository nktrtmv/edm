namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Updates.Workflows.Approval.Statuses;

public enum DocumentApprovalStatus
{
    None = 0,
    Approved = 1,
    Cancelled = 2,
    ToRework = 3,
    ApprovedWithRemark = 4
}
