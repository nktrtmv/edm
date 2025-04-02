using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetAllowedStatuses.Contracts;

public sealed record GetDocumentsAllowedStatusesQueryInternal(string[] DocumentsIds) : IRequest<GetDocumentsAllowedStatusesQueryResponseInternal>;
