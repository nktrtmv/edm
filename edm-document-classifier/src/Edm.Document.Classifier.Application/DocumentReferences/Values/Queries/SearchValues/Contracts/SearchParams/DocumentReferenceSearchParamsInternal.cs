using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams.Keys;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;

public sealed class DocumentReferenceSearchParamsInternal(DocumentReferenceKeyInternal key, string[] ids, string search, int skip, int limit)
{
    private const int DefaultLimit = 20;

    internal DocumentReferenceKeyInternal Key { get; } = key;
    internal string[] Ids { get; } = ids;
    internal string Search { get; } = search;
    internal int Skip { get; } = skip;
    internal int Limit { get; } = limit != 0 ? limit : DefaultLimit;
}
