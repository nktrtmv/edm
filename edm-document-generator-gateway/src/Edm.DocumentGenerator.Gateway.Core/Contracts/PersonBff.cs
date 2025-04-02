using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts;

public sealed record PersonBff(ReferenceTypeValueBff Value) : ReferenceValueWithType(DefaultKey, Value)
{
    private static readonly ReferenceTypeKey DefaultKey = new ReferenceTypeKey("{\"TypeId\":300}", string.Empty, null);

    public static PersonBff CreateNotEnriched(string id)
    {
        var value = ReferenceTypeValueBff.CreateNotEnriched(id);
        var result = new PersonBff(value);

        return result;
    }
}
