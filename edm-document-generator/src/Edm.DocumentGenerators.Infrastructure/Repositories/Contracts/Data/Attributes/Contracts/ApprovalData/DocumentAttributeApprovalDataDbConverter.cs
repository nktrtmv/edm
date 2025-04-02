using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData.Factories;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Contracts.ApprovalData;

internal static class DocumentAttributeApprovalDataDbConverter
{
    internal static DocumentAttributeApprovalDataDb FromDomain(DocumentAttributeApprovalData data)
    {
        var result = new DocumentAttributeApprovalDataDb
        {
            MetadataId = data.MetadataId,
            IsParticipant = data.IsParticipant
        };

        return result;
    }

    internal static DocumentAttributeApprovalData ToDomain(DocumentAttributeApprovalDataDb data)
    {
        DocumentAttributeApprovalData result = DocumentAttributeApprovalDataFactory.CreateFrom(data.MetadataId, data.IsParticipant);

        return result;
    }
}
