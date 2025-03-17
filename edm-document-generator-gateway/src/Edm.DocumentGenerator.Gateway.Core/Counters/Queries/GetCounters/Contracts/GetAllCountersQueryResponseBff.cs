using Edm.DocumentGenerator.Gateway.Core.Counters.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Queries.GetCounters.Contracts;

public sealed class GetAllCountersQueryResponseBff(DocumentCounterBff[] counters)
{
    public DocumentCounterBff[] Counters { get; } = counters;
}
