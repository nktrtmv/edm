namespace Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get.Contracts;

public sealed class GetCounterQueryBff
{
    public required string DomainId { get; init; }
    public required string Id { get; init; }
}
