using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Filters;

public sealed class TemplatesIdsByReadyForDocumentCreationFilterService(IDocumentsTemplatesRepository templates)
{
    internal async Task<Id<DocumentTemplate>[]> Filter(DomainId domainId, Id<DocumentTemplate>[] potentialTemplatesIds, CancellationToken cancellationToken)
    {
        if (potentialTemplatesIds.Length == 0)
        {
            return [];
        }

        DocumentTemplate[] templatesIds = await templates.GetByIds(domainId, potentialTemplatesIds, cancellationToken);

        Id<DocumentTemplate>[] result = templatesIds
            .Where(t => t.Status is DocumentTemplateStatus.ReadyForDocumentCreation)
            .Select(t => IdConverterFrom<DocumentTemplate>.From(t.Id))
            .ToArray();

        return result;
    }
}
