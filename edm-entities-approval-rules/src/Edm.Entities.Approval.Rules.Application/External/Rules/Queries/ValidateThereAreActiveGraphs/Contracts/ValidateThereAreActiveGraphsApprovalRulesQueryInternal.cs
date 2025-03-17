using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.ValidateThereAreActiveGraphs.Contracts;

public sealed class ValidateThereAreActiveGraphsApprovalRulesQueryInternal : IRequest
{
    public ValidateThereAreActiveGraphsApprovalRulesQueryInternal(EntityTypeKeyInternal entityTypeKey, string[] approvalGraphsTags)
    {
        EntityTypeKey = entityTypeKey;
        ApprovalGraphsTags = approvalGraphsTags;
    }

    internal EntityTypeKeyInternal EntityTypeKey { get; }
    internal string[] ApprovalGraphsTags { get; }
}
