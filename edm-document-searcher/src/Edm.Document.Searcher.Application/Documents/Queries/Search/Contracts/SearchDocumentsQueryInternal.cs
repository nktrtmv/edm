using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Queries.Search.Contracts;

public sealed record SearchDocumentsQueryInternal(
    string DomainId,
    SearchDocumentsQueryFilterInternal[] Filters,
    SearchDocumentsQuerySortParametersInternal SortParameters,
    int Limit,
    int Skip) : IRequest<SearchDocumentsQueryInternalResponse>;
