namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts;

public sealed class GetAllDocumentCountersQueryResponse(DocumentCounterExternal[] counters)
{
    public DocumentCounterExternal[] Counters { get; } = counters;
}
