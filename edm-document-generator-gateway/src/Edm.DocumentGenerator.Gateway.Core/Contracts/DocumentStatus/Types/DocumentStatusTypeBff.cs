namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;

public enum DocumentStatusTypeBff
{
    None = 0,
    Initial = 1,
    Backlog = 2,
    Simple = 3,
    Approval = 4,
    Signing = 5,
    Completed = 6,
    Cancelled = 7
}
