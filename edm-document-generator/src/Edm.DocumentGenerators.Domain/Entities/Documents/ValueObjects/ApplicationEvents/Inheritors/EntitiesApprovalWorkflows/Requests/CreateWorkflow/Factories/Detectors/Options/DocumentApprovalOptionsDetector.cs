using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByIds.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Boolean;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.ReferenceAttributes;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Options;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Constants;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Factories.Detectors
    .Options;

internal static class DocumentApprovalOptionsDetector
{
    internal static DocumentApprovalOptions Detect(Document document)
    {
        bool approvingWithRemarkIsDisabled =
            BooleanStatusParameterDetector.IsSet(document.Status, DocumentStatusParameterKind.ApprovalExitApprovedWithRemarkIsOff);

        const bool autoInProgressAssignmentsIsDisabled = false;

        Id<DocumentAttribute>[] approvalWatchersAttributesIds =
            ReferenceAttributeStatusParameterDetector.GetValues(document.Status, DocumentStatusParameterKind.Watchers);

        Id<User>[] approvalWatchersUserIds = approvalWatchersAttributesIds
            .Select(a => FetchWatcher(document, a))
            .OfType<Id<User>>()
            .ToArray();

        var result = new DocumentApprovalOptions(approvingWithRemarkIsDisabled, autoInProgressAssignmentsIsDisabled, approvalWatchersUserIds);

        return result;
    }

    private static Id<User>? FetchWatcher(Document document, Id<DocumentAttribute>? stageOwnerAttributeValueId)
    {
        if (stageOwnerAttributeValueId is null)
        {
            return null;
        }

        var fetcher = new DocumentAttributesValuesFetcher(document.AttributesValues);

        var selector = new DocumentReferenceAttributeValueByIdSelector(stageOwnerAttributeValueId, DocumentAttributeReferenceTypes.Employees);

        string? watcherId = fetcher.FetchSingleAttributeWithSingleValueOrNull(selector);

        if (watcherId is null)
        {
            return null;
        }

        Id<User> result = IdConverterFrom<User>.FromString(watcherId);

        return result;
    }
}
