using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Strings;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Statuses.Collectors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.RequiredApprovalGraphsTags;

public static class RequiredApprovalGraphsTagsCollector
{
    public static string[] Collect(DocumentTemplateStatus status, DocumentStatusTransition[] statusTransitions)
    {
        if (status != DocumentTemplateStatus.ReadyForDocumentCreation)
        {
            return Array.Empty<string>();
        }

        DocumentStatus[] statuses = DocumentStatusesCollector.Collect(statusTransitions);

        DocumentStatus[] approvalStatuses = statuses
            .Where(s => s.Type == DocumentStatusType.Approval)
            .ToArray();

        string[] result = approvalStatuses
            .Select(s => StringStatusParameterDetector.GetTrimmedValueOrNull(s, DocumentStatusParameterKind.ApprovalGraphTag))
            .OfType<string>()
            .Distinct()
            .ToArray();

        return result;
    }
}
