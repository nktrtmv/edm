using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types.Inheritors.References;

public sealed record ReferenceDocumentRegistryRoleTypeInternal(DocumentReferenceTypeId ReferenceId, ReferenceRegistryRoleDisplayType DisplayType)
    : DocumentRegistryRoleTypeInternal;
