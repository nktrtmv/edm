using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Edges;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;

public sealed record ApprovalGraphInternal(
    Id<ApprovalGraphInternal> Id,
    ApprovalGraphStatusInternal Status,
    ApprovalGraphEdgeInternal[] Edges,
    ApprovalGraphNodeInternal[] Nodes,
    ChiefApprovalStageInternal ChiefApproval,
    Metadata<FrontInternal> FrontMetadata,
    string DisplayName,
    string Tag);
