namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetNewReferenceTypeId.Contracts;

public sealed record GetNewReferenceTypeIdQueryResponseBff
{
    public required string ReferenceType { get; init; }
}
