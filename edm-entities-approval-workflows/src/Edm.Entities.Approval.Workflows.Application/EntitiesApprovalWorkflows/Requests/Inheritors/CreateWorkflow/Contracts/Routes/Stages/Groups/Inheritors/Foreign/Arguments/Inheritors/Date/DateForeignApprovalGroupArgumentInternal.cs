using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.Date;

public sealed class DateForeignApprovalGroupArgumentInternal
    : ForeignApprovalGroupArgumentGenericInternal<UtcDateTime<DateForeignApprovalGroupArgumentInternal>>
{
    public DateForeignApprovalGroupArgumentInternal(
        Id<ForeignApprovalGroupArgumentInternal> id,
        UtcDateTime<DateForeignApprovalGroupArgumentInternal>[] value) : base(id, value)
    {
    }
}
