using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch.Contracts;

public sealed record GetReferencesTypeValuesSearchQueryBffResponse
{
    public required ReferenceTypeValueBff[] Items { get; init; }
}
