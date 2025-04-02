using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Foreign.Arguments;

public abstract class ForeignApprovalGroupArgument
{
    protected ForeignApprovalGroupArgument(Id<ForeignApprovalGroupArgument> id)
    {
        Id = id;
    }

    public Id<ForeignApprovalGroupArgument> Id { get; }

    protected string BaseToString()
    {
        return $"Type: {GetType().Name}, Id: {Id}";
    }
}
