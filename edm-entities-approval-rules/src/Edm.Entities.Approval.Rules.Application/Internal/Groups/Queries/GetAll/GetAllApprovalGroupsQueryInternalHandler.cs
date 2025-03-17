using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.QueryParams;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers.QueryParams;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllApprovalGroupsQueryInternalHandler : IRequestHandler<GetAllApprovalGroupsQueryInternal, GetAllApprovalGroupsQueryResponseInternal>
{
    private ApprovalRulesFacade Rules { get; }

    public GetAllApprovalGroupsQueryInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    public async Task<GetAllApprovalGroupsQueryResponseInternal> Handle(GetAllApprovalGroupsQueryInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, cancellationToken);

        GetAllApprovalGroupsQueryParams queryParams =
            GetAllApprovalGroupsQueryParamsInternalConverter.ToDomain(request.QueryParams);

        ApprovalGroup[] groups = ApprovalGroupsFetcher.GetAll(rule, queryParams);

        GetAllApprovalGroupsQueryResponseInternal result =
            GetAllApprovalGroupsQueryResponseInternalConverter.FromDomain(groups);

        return result;
    }
}
