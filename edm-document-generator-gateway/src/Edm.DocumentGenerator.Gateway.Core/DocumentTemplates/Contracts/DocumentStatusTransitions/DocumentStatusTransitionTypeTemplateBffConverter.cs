using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;

internal static class DocumentStatusTransitionTypeTemplateBffConverter
{
    public static DocumentStatusTransitionTypeTemplateBff ToBff(DocumentStatusTransitionTypeDto dto)
    {
        var result = dto switch
        {
            DocumentStatusTransitionTypeDto.Manual => DocumentStatusTransitionTypeTemplateBff.Manual,
            DocumentStatusTransitionTypeDto.ApprovalToApproved => DocumentStatusTransitionTypeTemplateBff.ApprovalToApproved,
            DocumentStatusTransitionTypeDto.ApprovalToCancelled => DocumentStatusTransitionTypeTemplateBff.ApprovalToCancelled,
            DocumentStatusTransitionTypeDto.ApprovalToRework => DocumentStatusTransitionTypeTemplateBff.ApprovalToRework,
            DocumentStatusTransitionTypeDto.ApprovalToApprovedWithRemark => DocumentStatusTransitionTypeTemplateBff.ApprovalToApprovedWithRemark,

            DocumentStatusTransitionTypeDto.SigningToSigned => DocumentStatusTransitionTypeTemplateBff.SigningToSigned,
            DocumentStatusTransitionTypeDto.SigningToCancelled => DocumentStatusTransitionTypeTemplateBff.SigningToCancelled,
            DocumentStatusTransitionTypeDto.SigningToPreparation => DocumentStatusTransitionTypeTemplateBff.SigningToPreparation,
            DocumentStatusTransitionTypeDto.SigningToRework => DocumentStatusTransitionTypeTemplateBff.SigningToRework,

            _ => throw new ArgumentTypeOutOfRangeException(dto)
        };

        return result;
    }

    public static DocumentStatusTransitionTypeDto ToDto(DocumentStatusTransitionTypeTemplateBff bff)
    {
        var result = bff switch
        {
            DocumentStatusTransitionTypeTemplateBff.Manual => DocumentStatusTransitionTypeDto.Manual,
            DocumentStatusTransitionTypeTemplateBff.ApprovalToApproved => DocumentStatusTransitionTypeDto.ApprovalToApproved,
            DocumentStatusTransitionTypeTemplateBff.ApprovalToCancelled => DocumentStatusTransitionTypeDto.ApprovalToCancelled,
            DocumentStatusTransitionTypeTemplateBff.ApprovalToRework => DocumentStatusTransitionTypeDto.ApprovalToRework,
            DocumentStatusTransitionTypeTemplateBff.ApprovalToApprovedWithRemark => DocumentStatusTransitionTypeDto.ApprovalToApprovedWithRemark,

            DocumentStatusTransitionTypeTemplateBff.SigningToSigned => DocumentStatusTransitionTypeDto.SigningToSigned,
            DocumentStatusTransitionTypeTemplateBff.SigningToCancelled => DocumentStatusTransitionTypeDto.SigningToCancelled,
            DocumentStatusTransitionTypeTemplateBff.SigningToPreparation => DocumentStatusTransitionTypeDto.SigningToPreparation,
            DocumentStatusTransitionTypeTemplateBff.SigningToRework => DocumentStatusTransitionTypeDto.SigningToRework,

            _ => throw new ArgumentTypeOutOfRangeException(bff)
        };

        return result;
    }
}
