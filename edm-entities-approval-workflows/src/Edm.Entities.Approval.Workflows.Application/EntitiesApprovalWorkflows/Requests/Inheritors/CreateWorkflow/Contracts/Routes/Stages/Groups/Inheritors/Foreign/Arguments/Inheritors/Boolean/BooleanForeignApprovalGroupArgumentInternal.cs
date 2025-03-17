using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Boolean;

public sealed class BooleanForeignApprovalGroupArgumentInternal : ForeignApprovalGroupArgumentGenericInternal<bool>
{
    public BooleanForeignApprovalGroupArgumentInternal(Id<ForeignApprovalGroupArgumentInternal> id, bool[] value) : base(id, value)
    {
    }
}
