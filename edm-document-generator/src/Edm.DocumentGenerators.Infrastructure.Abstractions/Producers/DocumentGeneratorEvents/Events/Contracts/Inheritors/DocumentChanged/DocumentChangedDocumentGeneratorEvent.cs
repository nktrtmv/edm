using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts.Inheritors.DocumentChanged;

public sealed record DocumentChangedDocumentGeneratorEvent(
    DomainId DomainId,
    Id<Document> DocumentId) : DocumentGeneratorEvent(DomainId, DocumentId);
