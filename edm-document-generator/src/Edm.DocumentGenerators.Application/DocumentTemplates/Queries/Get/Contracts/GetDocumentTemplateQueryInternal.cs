using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts;

public sealed record GetDocumentTemplateQueryInternal(string DomainId, string Id) : IRequest<GetDocumentTemplateQueryInternalResponse>;
