using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData.Factories;

public static class DocumentTemplateApprovalDataFactory
{
    public static DocumentTemplateApprovalData CreateFrom(int customAttributeApprovalMetadataId, UtcDateTime<DocumentTemplate> attributesVersion)
    {
        var result = new DocumentTemplateApprovalData(customAttributeApprovalMetadataId, attributesVersion);

        return result;
    }

    public static DocumentTemplateApprovalData CreateNew()
    {
        var result = new DocumentTemplateApprovalData(DocumentTemplateApprovalData.CustomAttributeApprovalMetadataStartId, null);

        return result;
    }

    public static DocumentTemplateApprovalData CreateFromDb(
        int customAttributeApprovalMetadataId,
        UtcDateTime<DocumentTemplate>? attributesVersion)
    {
        var result = new DocumentTemplateApprovalData(customAttributeApprovalMetadataId, attributesVersion);

        return result;
    }
}
