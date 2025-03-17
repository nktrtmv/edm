using MediatR;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes.Contracts;

public sealed record GetDomainRegistryRolesInternalQuery(string DomainId, bool AllowOnlyUserMarkAttributeWithRole = false) : IRequest<GetDomainRegistryRolesInternalResponse>;
