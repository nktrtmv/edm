using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts;

internal static class GetAllApprovalRulesEntitiesTypesQueryBffConverter
{
    internal static GetAllApprovalRulesQuery ToDto(GetAllApprovalRulesQueryBff source)
    {
        var result = new GetAllApprovalRulesQuery
        {
            DomainId = source.DomainId,
            Search = source.Search
        };

        return result;
    }
}
