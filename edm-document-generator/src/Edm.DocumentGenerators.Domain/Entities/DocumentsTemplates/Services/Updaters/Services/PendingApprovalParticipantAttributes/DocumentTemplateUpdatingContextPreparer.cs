using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Contexts;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Detectors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Detectors.Contracts;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Updaters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes;

internal static class DocumentTemplateUpdatingContextPreparer
{
    internal static DocumentTemplateUpdatingContext? Prepare(DocumentTemplateUpdateParameters parameters, DocumentTemplate template)
    {
        if (parameters.UpdatedStatus == DocumentTemplateStatus.Draft)
        {
            return null;
        }

        ApprovalParticipantAttributesNeedUpdateDetectorResult? approvalAttributesDetectorResult =
            ApprovalParticipantAttributesNeedUpdateDetector.Detect(parameters, template);

        bool needUpdateApprovalRuleName = template.Name != parameters.UpdatedName;

        if (!approvalAttributesDetectorResult.NeedUpdate && !needUpdateApprovalRuleName)
        {
            return null;
        }

        if (approvalAttributesDetectorResult.AttributesToUpdate.Length == 0)
        {
            bool approvalParticipantAttributesHasNeverBeenPassed = template.ApprovalData.AttributesVersion is null;

            if (approvalParticipantAttributesHasNeverBeenPassed)
            {
                return null;
            }
        }

        if (approvalAttributesDetectorResult.NeedUpdate)
        {
            PendingApprovalParticipantAttributesMetadataIdsUpdater.Update(approvalAttributesDetectorResult.AttributesToUpdate, template);
        }

        var context = new DocumentTemplateUpdatingContext(approvalAttributesDetectorResult.AttributesToUpdate);

        return context;
    }
}
