using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment;
using Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Targets.Generics.SingleValue;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages;

public sealed class ContractorInternalEnricherTarget(ReferenceValueEnricherKey key, ContractorInternal? target)
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
