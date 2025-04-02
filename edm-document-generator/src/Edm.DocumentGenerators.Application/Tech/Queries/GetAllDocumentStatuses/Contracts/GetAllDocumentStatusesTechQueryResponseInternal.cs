using Edm.DocumentGenerators.Application.Contracts.Statuses;

namespace Edm.DocumentGenerators.Application.Tech.Queries.GetAllDocumentStatuses.Contracts;

public sealed record GetAllDocumentStatusesTechQueryResponseInternal(DocumentStatusInternal[] Statuses);
