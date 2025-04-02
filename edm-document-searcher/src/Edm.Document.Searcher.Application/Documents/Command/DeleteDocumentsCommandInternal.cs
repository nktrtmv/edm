using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Command;

public sealed record DeleteDocumentsCommandInternal(string DomainId, string[] DocumentIds) : IRequest;
