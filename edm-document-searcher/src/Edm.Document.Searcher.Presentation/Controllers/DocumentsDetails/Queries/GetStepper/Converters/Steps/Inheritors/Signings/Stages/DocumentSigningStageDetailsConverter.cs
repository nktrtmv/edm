using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings.Stages.Contractors;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings.Stages.Statuses;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings.Stages.Types;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings.Stages;

internal static class DocumentSigningStageDetailsConverter
{
    internal static DocumentSigningStageDetailsDto FromInternal(DocumentSigningStageDetailsInternal details)
    {
        var status = DocumentSigningStageStatusConverter.FromInternal(details.Status);
        var stageType = DocumentSigningStageTypeConverter.FromInternal(details.StageType);
        var contractor = NullableConverter.Convert(details.Contractor, ContractorConverter.FromInternal);

        var result = new DocumentSigningStageDetailsDto
        {
            Number = details.Number,
            StageType = stageType,
            Executor = details.Executor ?? string.Empty,
            Status = status,
            StatusChangedAt = details.StatusChangedAt.ToTimestamp(),
            CompletionComment = details.CompletionComment ?? string.Empty,
            Contractor = contractor,
            Id = details.Id
        };

        return result;
    }
}
