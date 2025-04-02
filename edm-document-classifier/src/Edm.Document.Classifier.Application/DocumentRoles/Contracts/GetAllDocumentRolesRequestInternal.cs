using MediatR;

namespace Edm.Document.Classifier.Application.DocumentRoles.Contracts;

public sealed record GetAllDocumentRolesRequestInternal(string DomainId) : IRequest<GetAllDocumentRolesResponseInternal>;
