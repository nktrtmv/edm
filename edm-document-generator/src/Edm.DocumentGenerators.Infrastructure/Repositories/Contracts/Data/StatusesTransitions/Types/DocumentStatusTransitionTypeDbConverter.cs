using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions.Types;

internal static class DocumentStatusTransitionTypeDbConverter
{
    internal static DocumentStatusTransitionTypeDb FromDomain(DocumentStatusTransitionType type)
    {
        DocumentStatusTransitionTypeDb result = type switch
        {
            DocumentStatusTransitionType.Manual => DocumentStatusTransitionTypeDb.Manual,
            DocumentStatusTransitionType.ApprovalToApproved => DocumentStatusTransitionTypeDb.ApprovalToApproved,
            DocumentStatusTransitionType.ApprovalToCancelled => DocumentStatusTransitionTypeDb.ApprovalToCancelled,
            DocumentStatusTransitionType.ApprovalToRework => DocumentStatusTransitionTypeDb.ApprovalToRework,
            DocumentStatusTransitionType.ApprovalToApprovedWithRemark => DocumentStatusTransitionTypeDb.ApprovalToApprovedWithRemark,
            DocumentStatusTransitionType.SigningToSigned => DocumentStatusTransitionTypeDb.SigningToSigned,
            DocumentStatusTransitionType.SigningToCancelled => DocumentStatusTransitionTypeDb.SigningToCancelled,
            DocumentStatusTransitionType.SigningToPreparation => DocumentStatusTransitionTypeDb.SigningToPreparation,
            DocumentStatusTransitionType.SigningToRework => DocumentStatusTransitionTypeDb.SigningToRework,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentStatusTransitionType ToDomain(DocumentStatusTransitionTypeDb type)
    {
        DocumentStatusTransitionType result = type switch
        {
            DocumentStatusTransitionTypeDb.Manual => DocumentStatusTransitionType.Manual,
            DocumentStatusTransitionTypeDb.ApprovalToApproved => DocumentStatusTransitionType.ApprovalToApproved,
            DocumentStatusTransitionTypeDb.ApprovalToCancelled => DocumentStatusTransitionType.ApprovalToCancelled,
            DocumentStatusTransitionTypeDb.ApprovalToRework => DocumentStatusTransitionType.ApprovalToRework,
            DocumentStatusTransitionTypeDb.ApprovalToApprovedWithRemark => DocumentStatusTransitionType.ApprovalToApprovedWithRemark,
            DocumentStatusTransitionTypeDb.SigningToSigned => DocumentStatusTransitionType.SigningToSigned,
            DocumentStatusTransitionTypeDb.SigningToCancelled => DocumentStatusTransitionType.SigningToCancelled,
            DocumentStatusTransitionTypeDb.SigningToPreparation => DocumentStatusTransitionType.SigningToPreparation,
            DocumentStatusTransitionTypeDb.SigningToRework => DocumentStatusTransitionType.SigningToRework,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
