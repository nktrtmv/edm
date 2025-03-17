using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Reference;

public sealed class ReferenceForeignApprovalGroupArgumentInternal
    : ForeignApprovalGroupArgumentGenericInternal<Id<ReferenceForeignApprovalGroupArgumentInternal>>
{
    public ReferenceForeignApprovalGroupArgumentInternal(
        Id<ForeignApprovalGroupArgumentInternal> id,
        Id<ReferenceForeignApprovalGroupArgumentInternal>[] value) : base(id, value)
    {
    }
}
