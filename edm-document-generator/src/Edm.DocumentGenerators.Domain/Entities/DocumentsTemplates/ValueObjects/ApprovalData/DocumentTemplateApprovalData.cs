using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData;

public sealed class DocumentTemplateApprovalData
{
    internal const int CustomAttributeApprovalMetadataStartId = 1000;

    internal DocumentTemplateApprovalData(int lastCustomAttributeApprovalMetadataId, UtcDateTime<DocumentTemplate>? attributesVersion)
    {
        LastCustomAttributeApprovalMetadataId = lastCustomAttributeApprovalMetadataId;
        AttributesVersion = attributesVersion;
    }

    public int LastCustomAttributeApprovalMetadataId { get; }
    public UtcDateTime<DocumentTemplate>? AttributesVersion { get; }
}
