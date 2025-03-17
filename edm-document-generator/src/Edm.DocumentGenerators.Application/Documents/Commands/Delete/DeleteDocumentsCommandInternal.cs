using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Delete;

public sealed record DeleteDocumentsCommandInternal(string DomainId, string[] DocumentIds) : IRequest;
