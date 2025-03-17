using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.ApprovalData.Factories;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.ApprovalData;

internal static class DocumentAttributeApprovalDataInternalConverter
{
    internal static DocumentAttributeApprovalDataInternal FromDomain(DocumentAttributeApprovalData data)
    {
        var result = new DocumentAttributeApprovalDataInternal
        {
            MetadataId = data.MetadataId,
            IsParticipant = data.IsParticipant
        };

        return result;
    }

    internal static DocumentAttributeApprovalData ToDomain(DocumentAttributeApprovalDataInternal data)
    {
        DocumentAttributeApprovalData result = DocumentAttributeApprovalDataFactory.CreateFrom(data.MetadataId, data.IsParticipant);

        return result;
    }
}
