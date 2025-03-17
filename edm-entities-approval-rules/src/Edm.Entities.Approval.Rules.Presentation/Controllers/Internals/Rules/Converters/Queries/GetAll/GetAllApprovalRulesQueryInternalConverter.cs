using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetAll;

internal static class GetAllApprovalRulesQueryInternalConverter
{
    internal static GetAllApprovalRulesQueryInternal FromDto(GetAllApprovalRulesQuery query)
    {
        DomainId domainId = DomainId.Parse(query.DomainId);

        var result = new GetAllApprovalRulesQueryInternal(domainId, query.Search);

        return result;
    }
}
