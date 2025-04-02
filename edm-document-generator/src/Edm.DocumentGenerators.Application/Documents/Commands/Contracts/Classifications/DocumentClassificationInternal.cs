namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.Classifications;

public sealed record DocumentClassificationInternal(
    string BusinessSegmentId,
    string DocumentCategoryId,
    string DocumentTypeId,
    string DocumentKindId);
