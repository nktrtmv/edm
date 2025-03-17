using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Detectors.Contracts;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Detectors.Helpers;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Detectors;

internal static class ApprovalParticipantAttributesNeedUpdateDetector
{
    internal static ApprovalParticipantAttributesNeedUpdateDetectorResult Detect(DocumentTemplateUpdateParameters parameters, DocumentTemplate template)
    {
        DocumentAttribute[] updatedApprovalParticipantAttributes =
            CollectApprovalParticipants(parameters.UpdatedAttributes);

        DocumentTemplateStatus originalStatus = template.Status;

        DocumentAttribute[] originalApprovalParticipantAttributes =
            CollectApprovalParticipants(parameters.OriginalAttributes);

        bool hasApprovalAttributesChanged =
            PendingApprovalParticipantAttributesChangeDetector.HasChanged(updatedApprovalParticipantAttributes, originalApprovalParticipantAttributes);

        if (originalStatus == DocumentTemplateStatus.Draft || hasApprovalAttributesChanged)
        {
            return new ApprovalParticipantAttributesNeedUpdateDetectorResult(true, updatedApprovalParticipantAttributes);
        }

        return new ApprovalParticipantAttributesNeedUpdateDetectorResult(false, updatedApprovalParticipantAttributes);
    }

    private static DocumentAttribute[] CollectApprovalParticipants(DocumentAttribute[] attributes)
    {
        DocumentAttribute[] result = attributes
            .Where(a => a.Data.ApprovalData.IsParticipant)
            .ToArray();

        return result;
    }
}
