using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Updaters.Helpers;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Updaters;

internal static class PendingApprovalParticipantAttributesMetadataIdsUpdater
{
    internal static void Update(DocumentAttribute[] attributes, DocumentTemplate template)
    {
        int originalLastCustomAttributeMetadataId =
            template.ApprovalData.LastCustomAttributeApprovalMetadataId;

        int updatedLastCustomAttributeMetadataId =
            PendingApprovalParticipantAttributesApprovalMetadataIdAssigner.Assign(attributes, originalLastCustomAttributeMetadataId);

        UpdateTemplateApprovalData(template, updatedLastCustomAttributeMetadataId);
    }

    private static void UpdateTemplateApprovalData(DocumentTemplate template, int updatedLastCustomAttributeMetadataId)
    {
        UtcDateTime<DocumentTemplate> attributesVersion = UtcDateTime<DocumentTemplate>.NowWithMicrosecondsPrecision;

        DocumentTemplateApprovalData approvalData = DocumentTemplateApprovalDataFactory.CreateFrom(updatedLastCustomAttributeMetadataId, attributesVersion);

        template.SetApprovalData(approvalData);
    }
}
