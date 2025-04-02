namespace Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;

public sealed record GetAllDocumentReferenceTypesQueryParams(string? Query, int Limit, int Skip, string[] Ids)
{
    public static readonly GetAllDocumentReferenceTypesQueryParams Instance = new GetAllDocumentReferenceTypesQueryParams(null, int.MaxValue, 0, []);
}
