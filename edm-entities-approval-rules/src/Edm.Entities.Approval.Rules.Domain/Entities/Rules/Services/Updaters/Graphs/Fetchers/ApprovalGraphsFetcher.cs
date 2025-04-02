using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Graphs.Fetchers;

public static class ApprovalGraphsFetcher
{
    public static ApprovalGraph GetRequired(ApprovalRule rule, Id<ApprovalGraph> id)
    {
        ApprovalGraph result = rule.Graphs.Single(r => r.Id == id);

        return result;
    }

    public static ApprovalGraph[] GetAll(ApprovalRule rule)
    {
        ApprovalGraph[] result = rule.Graphs;

        return result;
    }
}
