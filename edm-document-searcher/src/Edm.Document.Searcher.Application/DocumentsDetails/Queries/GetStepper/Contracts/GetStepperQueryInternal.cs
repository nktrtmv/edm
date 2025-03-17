using MediatR;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts;

public sealed record GetStepperQueryInternal(string Id, string DomainId) : IRequest<GetStepperQueryResponseInternal>;
