using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.TransitionParameters.
    CommentsWithAttachments;

internal static class CommentWithAttachmentsInDocumentStatusTransitionParameterAreFilledValidator
{
    internal static None Validate(DocumentCommentWithAttachmentsStatusTransitionParameterValue parameterValue)
    {
        if (parameterValue.Parameter.Kind is not DocumentStatusTransitionParameterKind.CommentWithAttachments)
        {
            throw new ArgumentValueOutOfRangeException(parameterValue.Parameter.Kind);
        }

        if (!string.IsNullOrWhiteSpace(parameterValue.Comment) && parameterValue.AttachmentsIds.Any())
        {
            return default;
        }

        throw new BusinessLogicApplicationException(
            $"Comment or attachments ids in status transition parameter should be filled (kind: {parameterValue.Parameter.Kind}).");
    }
}
