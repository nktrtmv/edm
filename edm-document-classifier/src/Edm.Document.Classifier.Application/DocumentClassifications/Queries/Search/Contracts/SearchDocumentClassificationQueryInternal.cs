using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search.Contracts;

public sealed class SearchDocumentClassificationQueryInternal : IRequest<SearchDocumentClassificationQueryInternalResponse>
{
    public SearchDocumentClassificationQueryInternal(string businessSegmentId, string categoryId, string typeId, string kindId)
    {
        BusinessSegmentId = businessSegmentId;
        CategoryId = categoryId;
        TypeId = typeId;
        KindId = kindId;
    }

    internal string BusinessSegmentId { get; }
    internal string CategoryId { get; }
    internal string TypeId { get; }
    internal string KindId { get; }
}
