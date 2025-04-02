using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Get.Contracts;

public sealed record GetApprovalRuleQueryInternal(EntityTypeKeyInternal EntityTypeKey) : IRequest<GetApprovalRuleQueryResponseInternal>;
