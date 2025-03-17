using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Targets.Generics.SingleValue;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Inheritors.Enums.Values;

namespace Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Inheritors.Enums.Targets;

public sealed class EnumEnricherTarget<T> : SingleValueEnricherTargetGeneric<int, string> where T : Enum
{
    private EnumEnricherTarget(EnumValue<T> target)
    {
        Target = target;
    }

    private EnumValue<T> Target { get; }

    protected override int GetKey()
    {
        return Target.Id;
    }

    protected override void EnrichTarget(string value)
    {
        Target.Value = value;
    }

    public static EnumValue<T> CreateNotEnriched(int id, EnrichersContext context)
    {
        var result = new EnumValue<T>(id);

        var enricher = new EnumEnricherTarget<T>(result);

        context.Add(enricher);

        return result;
    }
}
