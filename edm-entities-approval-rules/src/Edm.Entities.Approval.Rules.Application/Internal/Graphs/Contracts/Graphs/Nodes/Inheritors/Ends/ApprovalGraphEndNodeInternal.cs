using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Ends;

public sealed record ApprovalGraphEndNodeInternal(Id<ApprovalGraphNodeInternal> Id) : ApprovalGraphNodeInternal(Id);
