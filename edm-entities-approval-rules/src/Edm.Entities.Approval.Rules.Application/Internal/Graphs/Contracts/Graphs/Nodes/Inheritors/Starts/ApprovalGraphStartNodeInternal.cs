using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Starts;

public sealed record ApprovalGraphStartNodeInternal(Id<ApprovalGraphNodeInternal> Id) : ApprovalGraphNodeInternal(Id);
