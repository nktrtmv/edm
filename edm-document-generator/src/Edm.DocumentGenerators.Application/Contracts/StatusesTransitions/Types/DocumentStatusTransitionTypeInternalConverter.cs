using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Types;

internal static class DocumentStatusTransitionTypeInternalConverter
{
    internal static DocumentStatusTransitionTypeInternal FromDomain(DocumentStatusTransitionType type)
    {
        DocumentStatusTransitionTypeInternal result = type switch
        {
            DocumentStatusTransitionType.Manual => DocumentStatusTransitionTypeInternal.Manual,
            DocumentStatusTransitionType.ApprovalToApproved => DocumentStatusTransitionTypeInternal.ApprovalToApproved,
            DocumentStatusTransitionType.ApprovalToCancelled => DocumentStatusTransitionTypeInternal.ApprovalToCancelled,
            DocumentStatusTransitionType.ApprovalToRework => DocumentStatusTransitionTypeInternal.ApprovalToRework,
            DocumentStatusTransitionType.ApprovalToApprovedWithRemark => DocumentStatusTransitionTypeInternal.ApprovalToApprovedWithRemark,
            DocumentStatusTransitionType.SigningToSigned => DocumentStatusTransitionTypeInternal.SigningToSigned,
            DocumentStatusTransitionType.SigningToCancelled => DocumentStatusTransitionTypeInternal.SigningToCancelled,
            DocumentStatusTransitionType.SigningToPreparation => DocumentStatusTransitionTypeInternal.SigningToPreparation,
            DocumentStatusTransitionType.SigningToRework => DocumentStatusTransitionTypeInternal.SigningToRework,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentStatusTransitionType ToDomain(DocumentStatusTransitionTypeInternal type)
    {
        DocumentStatusTransitionType result = type switch
        {
            DocumentStatusTransitionTypeInternal.Manual => DocumentStatusTransitionType.Manual,
            DocumentStatusTransitionTypeInternal.ApprovalToApproved => DocumentStatusTransitionType.ApprovalToApproved,
            DocumentStatusTransitionTypeInternal.ApprovalToCancelled => DocumentStatusTransitionType.ApprovalToCancelled,
            DocumentStatusTransitionTypeInternal.ApprovalToRework => DocumentStatusTransitionType.ApprovalToRework,
            DocumentStatusTransitionTypeInternal.ApprovalToApprovedWithRemark => DocumentStatusTransitionType.ApprovalToApprovedWithRemark,
            DocumentStatusTransitionTypeInternal.SigningToSigned => DocumentStatusTransitionType.SigningToSigned,
            DocumentStatusTransitionTypeInternal.SigningToCancelled => DocumentStatusTransitionType.SigningToCancelled,
            DocumentStatusTransitionTypeInternal.SigningToPreparation => DocumentStatusTransitionType.SigningToPreparation,
            DocumentStatusTransitionTypeInternal.SigningToRework => DocumentStatusTransitionType.SigningToRework,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
