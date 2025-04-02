namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts;

internal sealed class SearchDocumentDb
{
    internal required string Id { get; init; }
    internal required string TemplateId { get; init; }
    internal required string DomainId { get; init; }
    internal required string AttributesValues { get; init; }
    internal required DateTime ConcurrencyToken { get; init; }
}
