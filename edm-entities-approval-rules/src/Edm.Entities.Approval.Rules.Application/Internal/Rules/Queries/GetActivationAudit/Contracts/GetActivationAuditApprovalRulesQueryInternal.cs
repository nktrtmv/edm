using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetActivationAudit.Contracts;

public sealed class GetActivationAuditApprovalRulesQueryInternal : IRequest<GetActivationAuditApprovalRulesQueryResponseInternal>
{
    public GetActivationAuditApprovalRulesQueryInternal(EntityTypeKeyInternal entityTypeKey)
    {
        EntityTypeKey = entityTypeKey;
    }

    public EntityTypeKeyInternal EntityTypeKey { get; }
}
