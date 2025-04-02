using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts;

public sealed record GetDocumentQueryInternalResponse(DocumentDetailedInternal? Document);
