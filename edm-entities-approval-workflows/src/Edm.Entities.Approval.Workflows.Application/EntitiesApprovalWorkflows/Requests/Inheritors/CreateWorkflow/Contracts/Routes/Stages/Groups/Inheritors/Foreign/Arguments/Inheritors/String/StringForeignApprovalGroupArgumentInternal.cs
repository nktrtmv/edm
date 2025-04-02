using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments.Inheritors.String;

public sealed class StringForeignApprovalGroupArgumentInternal : ForeignApprovalGroupArgumentGenericInternal<string>
{
    public StringForeignApprovalGroupArgumentInternal(Id<ForeignApprovalGroupArgumentInternal> id, string[] value) : base(id, value)
    {
    }
}
