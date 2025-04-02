using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.ProcessAll.Contracts;

public sealed record ProcessAllDocumentsCommandInternal(string DomainId) : IRequest;
