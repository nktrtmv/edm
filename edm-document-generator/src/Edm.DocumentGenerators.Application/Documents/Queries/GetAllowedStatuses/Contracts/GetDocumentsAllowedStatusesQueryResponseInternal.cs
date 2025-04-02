using Edm.DocumentGenerators.Application.Contracts.Statuses;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetAllowedStatuses.Contracts;

public sealed record GetDocumentsAllowedStatusesQueryResponseInternal(DocumentStatusInternal[] Statuses);
