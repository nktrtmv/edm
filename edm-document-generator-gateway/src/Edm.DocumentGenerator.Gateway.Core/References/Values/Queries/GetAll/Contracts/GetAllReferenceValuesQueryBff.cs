namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll.Contracts;

public sealed record GetAllReferenceValuesQueryBff(int Skip, int Limit)
{
    public required string DomainId { get; init; }
    public required string ReferenceType { get; init; }
    public string? Query { get; set; }
}
