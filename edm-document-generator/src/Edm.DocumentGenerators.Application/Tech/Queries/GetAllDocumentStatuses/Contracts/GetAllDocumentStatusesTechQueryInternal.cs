using MediatR;

namespace Edm.DocumentGenerators.Application.Tech.Queries.GetAllDocumentStatuses.Contracts;

public sealed record GetAllDocumentStatusesTechQueryInternal(string DocumentId) : IRequest<GetAllDocumentStatusesTechQueryResponseInternal>;
