using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.Services.Creators.Numbering.Counters;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.Services.Creators;

[UsedImplicitly]
internal sealed class DocumentsCreatorService(
    DocumentsFacade documentsFacade,
    DocumentsTemplatesFacade templatesFacade,
    IDocumentNumberingCounters numberingCounters)
{
    public async Task<Id<DocumentInternal>> Create(
        DomainId domainId,
        Id<DocumentTemplate> templateId,
        Id<User> currentUserId,
        DocumentClassification? classification,
        CancellationToken cancellationToken)
    {
        DocumentTemplate? template = await templatesFacade.GetRequired(domainId, templateId, cancellationToken);

        CounterValue[] counters = await numberingCounters.Increment(template);

        var creationContext = new DocumentCreationContext(template, counters, classification, currentUserId);
        Document? document = DocumentFactory.CreateNew(creationContext);

        await documentsFacade.Upsert(document, cancellationToken);

        Id<DocumentInternal> result = IdConverterFrom<DocumentInternal>.From(document.Id);

        return result;
    }
}
