using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages;

public sealed record ContractorBff(ReferenceTypeValueBff Value) : ReferenceValueWithType(DefaultKey, Value)
{
    private static readonly ReferenceTypeKey DefaultKey = new ReferenceTypeKey("{\"TypeId\":600}", string.Empty, null);

    public static ContractorBff CreateNotEnriched(string id)
    {
        var value = ReferenceTypeValueBff.CreateNotEnriched(id);
        var result = new ContractorBff(value);

        return result;
    }
}
