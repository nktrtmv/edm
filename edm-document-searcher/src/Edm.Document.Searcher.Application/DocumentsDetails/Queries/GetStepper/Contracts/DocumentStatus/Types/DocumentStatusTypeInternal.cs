namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Types;

public enum DocumentStatusTypeInternal
{
    None =  0,
    Initial = 1,
    Backlog = 2,
    Simple = 3,
    Approval = 4,
    Signing = 5,
    Completed = 6,
    Cancelled = 7,
}
