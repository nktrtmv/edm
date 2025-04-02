using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Events.DocumentGenerators.DocumentChanged.Contracts;

public sealed record DocumentChangedDocumentGeneratorEventInternal(
    string DomainId,
    Id<SearchDocumentInternal> DocumentId) : IRequest;
