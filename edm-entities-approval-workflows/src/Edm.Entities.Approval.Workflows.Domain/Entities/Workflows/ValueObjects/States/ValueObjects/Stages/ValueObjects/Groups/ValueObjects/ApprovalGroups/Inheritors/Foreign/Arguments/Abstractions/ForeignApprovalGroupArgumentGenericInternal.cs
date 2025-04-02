using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Foreign.Arguments.Abstractions;

public abstract class ForeignApprovalGroupArgumentGeneric<T> : ForeignApprovalGroupArgument
{
    protected ForeignApprovalGroupArgumentGeneric(Id<ForeignApprovalGroupArgument> id, T[] value) : base(id)
    {
        Value = value;
    }

    public T[] Value { get; }

    public override string ToString()
    {
        string value = string.Join(", ", Value);

        return $"{{ {BaseToString()}, Value: [{value}] }}";
    }
}
