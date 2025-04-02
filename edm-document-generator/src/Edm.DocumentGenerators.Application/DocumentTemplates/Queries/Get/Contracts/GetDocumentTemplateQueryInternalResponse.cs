using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts;

public sealed record GetDocumentTemplateQueryInternalResponse(DocumentTemplateDetailedInternal? Template);
