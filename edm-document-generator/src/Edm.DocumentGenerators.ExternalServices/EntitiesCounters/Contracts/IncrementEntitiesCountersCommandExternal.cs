using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Contracts;

public sealed record IncrementEntitiesCountersCommandExternal(Id<Counter>[] EntitiesCountersIds, string? EntityToken);
