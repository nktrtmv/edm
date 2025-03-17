using MediatR;

namespace Edm.DocumentGenerators.Application.Tech.Commands.ChangeDocumentStatus.Contracts;

public sealed record ChangeDocumentStatusTechCommandInternal(
    string DocumentId,
    string CurrentStatusId,
    string StatusToId,
    string UserId) : IRequest;
