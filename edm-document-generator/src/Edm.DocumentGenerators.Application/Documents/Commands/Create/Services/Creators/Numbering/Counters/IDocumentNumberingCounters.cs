using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.Services.Creators.Numbering.Counters;

public interface IDocumentNumberingCounters
{
    Task<CounterValue[]> Increment(DocumentTemplate template, string? entityToken = null);
}
