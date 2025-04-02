namespace Edm.DocumentGenerator.Gateway.GenericSubdomain;

public sealed class CollectionQueryResponse<T>
{
    public required IEnumerable<T> Items { get; set; }
    public required int Length { get; set; }
}
