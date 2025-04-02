using Edm.DocumentGenerator.Gateway.Core.References.Types.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Contracts;

public sealed record GetReferencesTypesQueryBffResponse
{
    public required ReferenceTypeBff[] References { get; init; }
}
