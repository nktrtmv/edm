namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData.Factories;

public static class DocumentAttributeApprovalDataFactory
{
    public static DocumentAttributeApprovalData CreateFrom(int metadataId, bool isParticipant)
    {
        var result = new DocumentAttributeApprovalData(metadataId, isParticipant);

        return result;
    }

    public static DocumentAttributeApprovalData CreateParticipantFrom(int metadataId)
    {
        DocumentAttributeApprovalData result = CreateFrom(metadataId, true);

        return result;
    }
}
