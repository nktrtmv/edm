using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Abstractions;

public abstract class ForeignApprovalGroupArgumentGenericInternal<T> : ForeignApprovalGroupArgumentInternal
{
    protected ForeignApprovalGroupArgumentGenericInternal(Id<ForeignApprovalGroupArgumentInternal> id, T[] value) : base(id)
    {
        Value = value;
    }

    public T[] Value { get; }
}
