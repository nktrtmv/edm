using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters;

internal static class GetStepperQueryResponseConverter
{
    internal static GetStepperQueryResponse FromInternal(GetStepperQueryResponseInternal response)
    {
        var steps = response.Steps.Select(GetStepperQueryResponseStepsConverter.FromInternal).ToArray();

        var result = new GetStepperQueryResponse
        {
            Steps = { steps },
            Id = response.Id,
            DomainId = response.DomainId
        };

        return result;
    }
}
