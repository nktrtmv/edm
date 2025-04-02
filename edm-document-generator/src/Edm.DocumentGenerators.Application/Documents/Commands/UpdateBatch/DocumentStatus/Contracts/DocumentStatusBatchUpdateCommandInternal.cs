using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus.Contracts;

public sealed record DocumentStatusBatchUpdateCommandInternal(string DomainId, string[] DocumentIds, string CurrentUserId, string NewStatusId)
    : IRequest<DocumentStatusBatchUpdateCommandInternalResponse>;
