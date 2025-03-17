using MediatR;

namespace Edm.Document.Classifier.Application.DomainActions.Contracts;

public sealed record GetDomainActionsQueryInternal(string DomainId) : IRequest<GetDomainActionsQueryResponseInternal>;
