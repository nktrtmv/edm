using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData.Factories;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;

public readonly record struct DocumentAttributeApprovalData
{
    public const int UnassignedMetadataId = -1;

    internal static readonly DocumentAttributeApprovalData Empty =
        DocumentAttributeApprovalDataFactory.CreateFrom(UnassignedMetadataId, false);

    //TODO Только для миграции маршрута согласования. Изменить public на internal
    public DocumentAttributeApprovalData(int metadataId, bool isParticipant)
    {
        MetadataId = metadataId;
        IsParticipant = isParticipant;
    }

    public int MetadataId { get; }
    public bool IsParticipant { get; }
}
