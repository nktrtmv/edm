using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Number;

public sealed class NumberForeignApprovalGroupArgumentInternal : ForeignApprovalGroupArgumentGenericInternal<long>
{
    public NumberForeignApprovalGroupArgumentInternal(Id<ForeignApprovalGroupArgumentInternal> id, long[] value) : base(id, value)
    {
    }
}
