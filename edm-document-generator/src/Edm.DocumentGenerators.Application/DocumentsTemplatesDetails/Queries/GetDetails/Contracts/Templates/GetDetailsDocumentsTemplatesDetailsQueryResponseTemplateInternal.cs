using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentsTemplatesDetails.Queries.GetDetails.Contracts.Templates;

public sealed record GetDetailsDocumentsTemplatesDetailsQueryResponseTemplateInternal(
    Id<DocumentTemplateInternal> Id,
    string Name,
    Id<UserInternal> LastUpdatedByUserId,
    DocumentTemplateStatus Status);
