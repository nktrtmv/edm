using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Sources.Generics.SingleKey;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Inheritors.Enums.Sources;

public sealed class EnumEnricherSource<T>
    : SingleKeyEnricherSourceGeneric<Dictionary<int, string>, int, string> where T : Enum
{
    public EnumEnricherSource(
        Dictionary<int, string> source,
        ILogger<EnumEnricherSource<T>> logger)
        : base(source, logger)
    {
    }

    protected override Task<Dictionary<int, string>> GetValues(int[] keys, CancellationToken cancellationToken)
    {
        Dictionary<int, string> result = Client
            .Where(p => keys.Contains(p.Key))
            .ToDictionary(p => p.Key, p => p.Value);

        return Task.FromResult(result);
    }

    public static EnumEnricherSource<T> Create(IServiceProvider services)
    {
        Dictionary<int, string> source = Enum.GetValues(typeof(T))
            .Cast<int>()
            .Where(v => v != 0)
            .ToDictionary(e => e, e => Enum.GetName(typeof(T), e)!);

        var result = ActivatorUtilities.CreateInstance<EnumEnricherSource<T>>(services, source);

        return result;
    }
}
