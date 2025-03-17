using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Services;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Graphs.Fetchers;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllApprovalGraphsQueryInternalHandler : IRequestHandler<GetAllApprovalGraphsQueryInternal, GetAllApprovalGraphsQueryResponseInternal>
{
    public GetAllApprovalGraphsQueryInternalHandler(ApprovalRulesFacade rules)
    {
        Rules = rules;
    }

    private ApprovalRulesFacade Rules { get; }

    public async Task<GetAllApprovalGraphsQueryResponseInternal> Handle(GetAllApprovalGraphsQueryInternal request, CancellationToken cancellationToken)
    {
        ApprovalRule rule = await Rules.GetRequired(request.ApprovalRuleKey, cancellationToken);

        ApprovalGraph[] graphs = ApprovalGraphsFetcher.GetAll(rule);

        GetAllApprovalGraphsQueryResponseInternal result =
            GetAllApprovalGraphsQueryResponseInternalConverter.FromDomain(graphs);

        return result;
    }
}
