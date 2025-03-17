using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData.Factories;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.ApprovalData;

internal static class DocumentTemplateApprovalDataDbConverter
{
    internal static DocumentTemplateApprovalDataDb FromDomain(DocumentTemplateApprovalData data)
    {
        Timestamp? attributesVersion =
            NullableConverter.Convert(data.AttributesVersion, UtcDateTimeConverterTo.ToTimeStamp);

        var result = new DocumentTemplateApprovalDataDb
        {
            LastCustomAttributeApprovalMetadataId = data.LastCustomAttributeApprovalMetadataId,
            AttributesVersion = attributesVersion
        };

        return result;
    }

    internal static DocumentTemplateApprovalData ToDomain(DocumentTemplateApprovalDataDb data)
    {
        UtcDateTime<DocumentTemplate>? attributesVersion =
            NullableConverter.Convert(data.AttributesVersion, UtcDateTimeConverterFrom<DocumentTemplate>.FromTimestamp);

        DocumentTemplateApprovalData result = DocumentTemplateApprovalDataFactory.CreateFromDb(
            data.LastCustomAttributeApprovalMetadataId,
            attributesVersion);

        return result;
    }
}
