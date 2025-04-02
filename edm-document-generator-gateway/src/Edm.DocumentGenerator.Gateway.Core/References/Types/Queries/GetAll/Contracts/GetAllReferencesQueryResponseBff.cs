using Edm.DocumentGenerator.Gateway.Core.References.Types.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll.Contracts;

public sealed record GetAllReferencesQueryResponseBff
{
    public required ReferenceTypeBff[] References { get; init; }
}
