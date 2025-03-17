namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts.QueryParams;

internal sealed record GetAllDocumentReferenceTypesQueryParamsDb(string? Query, int Limit, int Skip, string[] Ids);
