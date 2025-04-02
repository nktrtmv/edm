using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllApprovalRulesQueryInternalHandler
    : IRequestHandler<GetAllApprovalRulesQueryInternal, GetAllApprovalRulesQueryResponseInternal>
{
    public GetAllApprovalRulesQueryInternalHandler(IApprovalRulesRepository rules)
    {
        Rules = rules;
    }

    private IApprovalRulesRepository Rules { get; }

    public async Task<GetAllApprovalRulesQueryResponseInternal> Handle(GetAllApprovalRulesQueryInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = request.DomainId;

        ApprovalRule[] rules = await Rules.GetAllLatest(domainId, request.Search, cancellationToken);

        GetAllApprovalRulesQueryResponseInternal result =
            GetAllApprovalRulesQueryResponseInternalConverter.FromDomain(rules);

        return result;
    }
}
