namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors;

public abstract class ApprovalGroupDetails
{
    protected string BaseToString()
    {
        return $"Type: {GetType().Name}";
    }
}
