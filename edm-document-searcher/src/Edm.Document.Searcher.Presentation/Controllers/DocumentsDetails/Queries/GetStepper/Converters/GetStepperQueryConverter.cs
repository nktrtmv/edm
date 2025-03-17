using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters;

internal static class GetStepperQueryConverter
{
    internal static GetStepperQueryInternal ToInternal(GetStepperQuery query)
    {
        var result = new GetStepperQueryInternal(query.Id, query.DomainId);

        return result;
    }
}
