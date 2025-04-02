using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources.Generics.SingleKey;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Sources.Attributes;

internal sealed class EntityTypeAttributeDtoEnricherSource
    : SingleKeyEnricherSourceGeneric<EntityTypeAttributeDto[], int, EntityTypeAttributeDto>
{
    public EntityTypeAttributeDtoEnricherSource(
        EntityTypeAttributeDto[] client,
        ILogger<EntityTypeAttributeDtoEnricherSource> logger)
        : base(client, logger)
    {
    }

    protected override Task<Dictionary<int, EntityTypeAttributeDto>> GetValues(int[] keys, CancellationToken cancellationToken)
    {
        Dictionary<int, EntityTypeAttributeDto> result = Client.Where(a => keys.Contains(a.Data.Id)).ToDictionary(a => a.Data.Id);

        return Task.FromResult(result);
    }

    internal static EntityTypeAttributeDtoEnricherSource Create(IServiceProvider services, IEnumerable<EntityTypeAttributeDto> values)
    {
        EntityTypeAttributeDto[] client = values.ToArray();

        var result = ActivatorUtilities.CreateInstance<EntityTypeAttributeDtoEnricherSource>(services, (object)client);

        return result;
    }
}
