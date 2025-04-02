namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus.Contracts;

public sealed record DocumentStatusBatchUpdateCommandInternalResponse(string[] UncompletedDocumentIds);
