using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.StatusesTransitions.Types;

internal static class DocumentStatusTransitionTypeDtoConverter
{
    public static DocumentStatusTransitionTypeDto FromInternal(DocumentStatusTransitionTypeInternal type)
    {
        DocumentStatusTransitionTypeDto result = type switch
        {
            DocumentStatusTransitionTypeInternal.Manual => DocumentStatusTransitionTypeDto.Manual,
            DocumentStatusTransitionTypeInternal.ApprovalToApproved => DocumentStatusTransitionTypeDto.ApprovalToApproved,
            DocumentStatusTransitionTypeInternal.ApprovalToCancelled => DocumentStatusTransitionTypeDto.ApprovalToCancelled,
            DocumentStatusTransitionTypeInternal.ApprovalToRework => DocumentStatusTransitionTypeDto.ApprovalToRework,
            DocumentStatusTransitionTypeInternal.ApprovalToApprovedWithRemark => DocumentStatusTransitionTypeDto.ApprovalToApprovedWithRemark,
            DocumentStatusTransitionTypeInternal.SigningToSigned => DocumentStatusTransitionTypeDto.SigningToSigned,
            DocumentStatusTransitionTypeInternal.SigningToCancelled => DocumentStatusTransitionTypeDto.SigningToCancelled,
            DocumentStatusTransitionTypeInternal.SigningToPreparation => DocumentStatusTransitionTypeDto.SigningToPreparation,
            DocumentStatusTransitionTypeInternal.SigningToRework => DocumentStatusTransitionTypeDto.SigningToRework,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    public static DocumentStatusTransitionTypeInternal ToInternal(DocumentStatusTransitionTypeDto type)
    {
        DocumentStatusTransitionTypeInternal result = type switch
        {
            DocumentStatusTransitionTypeDto.Manual => DocumentStatusTransitionTypeInternal.Manual,
            DocumentStatusTransitionTypeDto.ApprovalToApproved => DocumentStatusTransitionTypeInternal.ApprovalToApproved,
            DocumentStatusTransitionTypeDto.ApprovalToCancelled => DocumentStatusTransitionTypeInternal.ApprovalToCancelled,
            DocumentStatusTransitionTypeDto.ApprovalToRework => DocumentStatusTransitionTypeInternal.ApprovalToRework,
            DocumentStatusTransitionTypeDto.ApprovalToApprovedWithRemark => DocumentStatusTransitionTypeInternal.ApprovalToApprovedWithRemark,
            DocumentStatusTransitionTypeDto.SigningToSigned => DocumentStatusTransitionTypeInternal.SigningToSigned,
            DocumentStatusTransitionTypeDto.SigningToCancelled => DocumentStatusTransitionTypeInternal.SigningToCancelled,
            DocumentStatusTransitionTypeDto.SigningToPreparation => DocumentStatusTransitionTypeInternal.SigningToPreparation,
            DocumentStatusTransitionTypeDto.SigningToRework => DocumentStatusTransitionTypeInternal.SigningToRework,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
