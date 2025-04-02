using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.Get;

[UsedImplicitly]
internal sealed class GetApprovalGroupsQueryInternalHandler : IRequestHandler<GetApprovalGroupsQueryInternal, GetApprovalGroupsQueryResponseInternal>
{
    public GetApprovalGroupsQueryInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task<GetApprovalGroupsQueryResponseInternal> Handle(GetApprovalGroupsQueryInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, cancellationToken);

        Id<ApprovalGroup> id = IdConverterFrom<ApprovalGroup>.From(request.GroupId);

        ApprovalGroup group = ApprovalGroupsFetcher.GetRequired(rule, id);

        GetApprovalGroupsQueryResponseInternal result =
            GetApprovalGroupsQueryResponseInternalConverter.FromDomain(group, rule);

        return result;
    }
}
