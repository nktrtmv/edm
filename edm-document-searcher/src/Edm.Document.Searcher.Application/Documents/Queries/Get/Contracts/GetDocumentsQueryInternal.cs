using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts;

public sealed record GetDocumentsQueryInternal(
    string DomainId,
    SearchDocumentsQueryFilterInternal[] Filters,
    SearchDocumentsQuerySortParametersInternal SortParameters,
    string[] DocumentsIds,
    int Limit,
    int Skip) : IRequest<GetDocumentsQueryInternalResponse>;
