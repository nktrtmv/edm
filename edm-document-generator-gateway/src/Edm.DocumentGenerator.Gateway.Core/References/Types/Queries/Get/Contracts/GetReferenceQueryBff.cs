namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get.Contracts;

public sealed record GetReferenceQueryBff
{
    public required string DomainId { get; init; }
    public required string ReferenceType { get; init; }
}
