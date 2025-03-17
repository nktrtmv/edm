using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings.Stages.Contractors;

internal static class ContractorConverter
{
    internal static ContractorDto FromInternal(ContractorInternal contractor)
    {
        return new ContractorDto
        {
            Id = contractor.Id,
            DisplayValue = contractor.DisplayValue,
            DisplaySubValue = contractor.DisplaySubValue
        };
    }
}
