using Edm.DocumentGenerator.Gateway.Core.Counters.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get.Contracts;

public sealed class GetCounterQueryResponseBff
{
    public required DocumentCounterBff Counter { get; init; }
}
