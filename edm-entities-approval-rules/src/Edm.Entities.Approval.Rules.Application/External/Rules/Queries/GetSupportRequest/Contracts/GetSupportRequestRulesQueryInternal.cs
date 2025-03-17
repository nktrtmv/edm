using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.GetSupportRequest.Contracts;

public sealed record GetSupportRequestRulesQueryInternal(DomainId DomainId) : IRequest<GetSupportRequestRulesQueryResponseInternal>;
