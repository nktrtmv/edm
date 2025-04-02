using MediatR;

namespace Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts;

public sealed record GetAllDocumentSystemAttributesQueryInternal(string DomainId) : IRequest<GetAllDocumentSystemAttributesQueryInternalResponse>;
