using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.GetSupportRequest.Contracts;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.GetSupportRequest.Contracts.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.GetSupportRequest;

[UsedImplicitly]
internal sealed class GetSupportRequestRulesQueryInternalHandler(IApprovalRulesRepository rules)
    : IRequestHandler<GetSupportRequestRulesQueryInternal, GetSupportRequestRulesQueryResponseInternal>
{
    public async Task<GetSupportRequestRulesQueryResponseInternal> Handle(GetSupportRequestRulesQueryInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = request.DomainId;

        ApprovalRule[] approvalRules = await rules.GetAllLatest(domainId, "", cancellationToken);

        GetSupportRequestRulesQueryResponseApprovalRuleInternal[] rulesInternal =
            approvalRules.Select(GetSupportRequestRulesQueryResponseApprovalRuleInternalConverter.FromDomain).ToArray();

        var result = new GetSupportRequestRulesQueryResponseInternal(rulesInternal);

        return result;
    }
}
