using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.GroupsDetails.Queries.GetParticipantSourceAttributes.Contracts;

public sealed record GetParticipantSourceAttributesApprovalGroupsDetailsQueryInternal(ApprovalRuleKeyInternal ApprovalRuleKey)
    : IRequest<GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseInternal>;
