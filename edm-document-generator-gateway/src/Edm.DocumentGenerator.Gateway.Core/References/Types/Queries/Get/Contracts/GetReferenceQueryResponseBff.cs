using Edm.DocumentGenerator.Gateway.Core.References.Types.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get.Contracts;

public sealed record GetReferenceQueryResponseBff
{
    public required ReferenceTypeBff Reference { get; init; }
}
