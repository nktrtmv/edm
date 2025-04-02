using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources.Generics.SingleKey;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get.Enrichers;

internal sealed class GetApprovalGraphsQueryResponseGroupEnricherSource
    : SingleKeyEnricherSourceGeneric<GetApprovalGraphsQueryResponseGroup[], string, GetApprovalGraphsQueryResponseGroup>
{
    public GetApprovalGraphsQueryResponseGroupEnricherSource(
        GetApprovalGraphsQueryResponseGroup[] client,
        ILogger<GetApprovalGraphsQueryResponseGroupEnricherSource> logger)
        : base(client, logger)
    {
    }

    protected override Task<Dictionary<string, GetApprovalGraphsQueryResponseGroup>> GetValues(string[] keys, CancellationToken cancellationToken)
    {
        Dictionary<string, GetApprovalGraphsQueryResponseGroup> result =
            Client.Where(a => keys.Contains(a.Id)).ToDictionary(a => a.Id);

        return Task.FromResult(result);
    }

    internal static GetApprovalGraphsQueryResponseGroupEnricherSource Create(IServiceProvider services, IEnumerable<GetApprovalGraphsQueryResponseGroup> values)
    {
        GetApprovalGraphsQueryResponseGroup[] client = values.ToArray();

        var result = ActivatorUtilities.CreateInstance<GetApprovalGraphsQueryResponseGroupEnricherSource>(services, (object)client);

        return result;
    }
}
