using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts;

public sealed class GetAllApprovalRulesQueryInternal : IRequest<GetAllApprovalRulesQueryResponseInternal>
{
    public GetAllApprovalRulesQueryInternal(DomainId domainId, string? search)
    {
        DomainId = domainId;
        Search = search;
    }

    internal DomainId DomainId { get; }
    internal string? Search { get; }
}
