using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Targets.ReferenceValues;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers.Abstractions.Targets.Generics.SingleValue;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages;

public sealed class ContractorBffEnricherTarget(ReferenceValueEnricherKey key, ContractorBff? target)
    : SingleValueEnricherTargetGeneric<ReferenceValueEnricherKey, ReferenceValueDto>
{
    protected override ReferenceValueEnricherKey GetKey()
    {
        return key;
    }

    protected override void EnrichTarget(ReferenceValueDto value)
    {
        if (target == null)
        {
            return;
        }

        target.DisplayValue = value.DisplayValue;
        target.DisplaySubValue = value.DisplaySubValue;
    }
}
