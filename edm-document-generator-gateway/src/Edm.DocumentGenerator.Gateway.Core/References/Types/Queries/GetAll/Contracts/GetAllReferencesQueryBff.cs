namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll.Contracts;

public sealed record GetAllReferencesQueryBff(int Skip, int Limit)
{
    public required string DomainId { get; init; }
    public string? Query { get; set; }
}
