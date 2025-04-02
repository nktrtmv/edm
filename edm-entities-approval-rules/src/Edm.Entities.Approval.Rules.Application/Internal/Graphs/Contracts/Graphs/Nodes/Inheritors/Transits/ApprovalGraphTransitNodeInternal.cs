using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Transits;

public sealed record ApprovalGraphTransitNodeInternal(Id<ApprovalGraphNodeInternal> Id) : ApprovalGraphNodeInternal(Id);
