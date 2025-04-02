using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts.QueryParams;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.GetAll.Contracts;

public sealed record GetAllDocumentTemplatesQueryInternal(
    string DomainId,
    GetAllDocumentsTemplatesQueryParamsInternal? QueryParams) : IRequest<GetAllDocumentTemplatesQueryInternalResponse>;
