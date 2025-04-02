namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetNewReferenceTypeId.Contracts;

public sealed record GetNewReferenceTypeIdQueryBff
{
    public required string DomainId { get; init; }
}
