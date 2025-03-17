using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Types;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;

public sealed record ApprovalGraphStageNodeInternal(
    Id<ApprovalGraphNodeInternal> Id,
    string DisplayName,
    string? Label,
    ApprovalGraphStageTypeInternal Type,
    ApprovalGraphStageSetInternal[] Sets) : ApprovalGraphNodeInternal(Id);
