using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts;

public sealed class GetVersionsApprovalRulesQueryInternal : IRequest<GetVersionsApprovalRulesQueryResponseInternal>
{
    public GetVersionsApprovalRulesQueryInternal(EntityTypeKeyInternal entityTypeKey)
    {
        EntityTypeKey = entityTypeKey;
    }

    internal EntityTypeKeyInternal EntityTypeKey { get; }
}
