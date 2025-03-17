using Edm.DocumentGenerators.Application.Contracts.Attributes.Contracts.ApprovalData;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.ApprovalData;

internal static class DocumentAttributeApprovalDataDtoConverter
{
    internal static bool FromInternal(DocumentAttributeApprovalDataInternal data)
    {
        bool result = data.IsParticipant;

        return result;
    }

    internal static DocumentAttributeApprovalDataInternal ToInternal(bool isApprovalParticipant)
    {
        var result = new DocumentAttributeApprovalDataInternal(-1, isApprovalParticipant);

        return result;
    }
}
