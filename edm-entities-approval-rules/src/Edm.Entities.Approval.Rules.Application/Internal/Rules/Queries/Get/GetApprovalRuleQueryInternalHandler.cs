using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Get;

[UsedImplicitly]
internal sealed class GetApprovalRuleQueryInternalHandler(IApprovalRulesRepository rules)
    : IRequestHandler<GetApprovalRuleQueryInternal, GetApprovalRuleQueryResponseInternal>
{
    public async Task<GetApprovalRuleQueryResponseInternal> Handle(GetApprovalRuleQueryInternal request, CancellationToken cancellationToken)
    {
        EntityTypeKey key = EntityTypeKeyInternalConverter.ToDomain(request.EntityTypeKey);

        ApprovalRule rule = await rules.GetRequired(key, cancellationToken);

        GetApprovalRuleQueryResponseInternal result = GetApprovalRuleQueryResponseInternalConverter.FromDomain(rule);

        return result;
    }
}
