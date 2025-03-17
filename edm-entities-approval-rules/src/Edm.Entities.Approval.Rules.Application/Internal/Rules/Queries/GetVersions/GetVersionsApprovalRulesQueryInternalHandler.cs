using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions;

[UsedImplicitly]
internal sealed class GetVersionsApprovalRulesQueryInternalHandler : IRequestHandler<GetVersionsApprovalRulesQueryInternal, GetVersionsApprovalRulesQueryResponseInternal>
{
    public GetVersionsApprovalRulesQueryInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task<GetVersionsApprovalRulesQueryResponseInternal> Handle(GetVersionsApprovalRulesQueryInternal request, CancellationToken cancellationToken)
    {
        EntityTypeKey entityTypeKey = EntityTypeKeyInternalConverter.ToDomain(request.EntityTypeKey);

        ApprovalRule[] rules = await Rules.GetAllVersions(entityTypeKey, true, cancellationToken);

        GetVersionsApprovalRulesQueryResponseInternal result =
            GetVersionsApprovalRulesQueryResponseInternalConverter.FromDomain(rules);

        return result;
    }
}
