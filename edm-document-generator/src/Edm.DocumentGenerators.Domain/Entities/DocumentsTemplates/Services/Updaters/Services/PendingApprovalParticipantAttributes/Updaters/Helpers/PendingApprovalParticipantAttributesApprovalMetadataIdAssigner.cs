using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData.Factories;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Updaters.
    Helpers;

internal static class PendingApprovalParticipantAttributesApprovalMetadataIdAssigner
{
    internal static int Assign(DocumentAttribute[] attributes, int lastCustomAttributeMetadataId)
    {
        foreach (DocumentAttribute attribute in attributes)
        {
            if (ShallIdBeAssigned(attribute.Data.ApprovalData))
            {
                AssignId(attribute, lastCustomAttributeMetadataId++);
            }
        }

        return lastCustomAttributeMetadataId;
    }

    private static bool ShallIdBeAssigned(DocumentAttributeApprovalData approvalData)
    {
        bool isParticipant = approvalData.IsParticipant;
        bool isUnassigned = approvalData.MetadataId == DocumentAttributeApprovalData.UnassignedMetadataId;

        bool result = isParticipant && isUnassigned;

        return result;
    }

    private static void AssignId(DocumentAttribute attribute, int approvalMetadataId)
    {
        DocumentAttributeApprovalData approvalData = DocumentAttributeApprovalDataFactory.CreateParticipantFrom(approvalMetadataId);

        attribute.Data.SetApprovalData(approvalData);
    }
}
