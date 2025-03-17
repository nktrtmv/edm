namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Types;

public enum DocumentStatusTypeInternal
{
    None = 0,
    Initial = 1,
    Backlog = 2,
    Simple = 3,
    Approval = 4,
    Signing = 6,
    Completed = 7,
    Cancelled = 8
}
