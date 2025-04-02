namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get.Contracts;

public sealed record GetReferenceValueQueryBff
{
    public required string DomainId { get; init; }
    public required string ReferenceType { get; init; }
    public required string Id { get; init; }
}
