using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Chief;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Custom;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic;
using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Chief;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Custom;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Domestic;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups.Inheritors.Foreign;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.ApprovalGroups;

internal static class ApprovalWorkflowApprovalGroupDbConverter
{
    internal static ApprovalWorkflowApprovalGroupDb FromDomain(ApprovalWorkflowApprovalGroup group)
    {
        var result = group switch
        {
            ApprovalWorkflowChiefApprovalGroup g =>
                ApprovalWorkflowChiefApprovalGroupDbConverter.FromDomain(g),

            ApprovalWorkflowCustomApprovalGroup g =>
                ApprovalWorkflowCustomApprovalGroupDbConverter.FromDomain(g),

            ApprovalWorkflowDomesticApprovalGroup g =>
                ApprovalWorkflowDomesticApprovalGroupDbConverter.FromDomain(g),

            ApprovalWorkflowForeignApprovalGroup g =>
                ApprovalWorkflowForeignApprovalGroupDbConverter.FromDomain(g),

            _ => throw new ArgumentTypeOutOfRangeException(group)
        };

        return result;
    }

    internal static ApprovalWorkflowApprovalGroup ToDomain(ApprovalWorkflowApprovalGroupDb group)
    {
        ApprovalWorkflowApprovalGroup result = group.GroupCase switch
        {
            ApprovalWorkflowApprovalGroupDb.GroupOneofCase.AsChief =>
                ApprovalWorkflowChiefApprovalGroupDbConverter.ToDomain(group.AsChief),

            ApprovalWorkflowApprovalGroupDb.GroupOneofCase.AsCustom =>
                ApprovalWorkflowCustomApprovalGroupDbConverter.ToDomain(group.AsCustom),

            ApprovalWorkflowApprovalGroupDb.GroupOneofCase.AsDomestic =>
                ApprovalWorkflowDomesticApprovalGroupDbConverter.ToDomain(group.AsDomestic),

            ApprovalWorkflowApprovalGroupDb.GroupOneofCase.AsForeign =>
                ApprovalWorkflowForeignApprovalGroupDbConverter.ToDomain(group.AsForeign),

            _ => throw new ArgumentTypeOutOfRangeException(group)
        };

        return result;
    }
}
