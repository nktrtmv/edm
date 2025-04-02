using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get.Contracts;

public sealed record GetReferenceValueQueryResponseBff
{
    public required ReferenceValueBff ReferenceValue { get; init; }
}
