using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.TransitionParameters.Comments;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.TransitionParameters.CommentsWithAttachments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.TransitionParameters;

internal static class TransitionParametersAreFilledValidator
{
    internal static void Validate(DocumentStatusTransitionParameterValue[] parametersValues)
    {
        bool[] comments = parametersValues
            .Select(v => v is DocumentCommentStatusTransitionParameterValue or DocumentCommentWithAttachmentsStatusTransitionParameterValue)
            .ToArray();

        if (comments.Length > 1)
        {
            throw new BusinessLogicApplicationException("There can be no more than 1 comment transition parameter value.");
        }

        Array.ForEach(parametersValues, Validate);
    }

    private static void Validate(DocumentStatusTransitionParameterValue parameterValue)
    {
        None _ = parameterValue switch
        {
            DocumentCommentStatusTransitionParameterValue p =>
                CommentInDocumentStatusTransitionParameterIsFilledValidator.Validate(p),

            DocumentCommentWithAttachmentsStatusTransitionParameterValue p =>
                CommentWithAttachmentsInDocumentStatusTransitionParameterAreFilledValidator.Validate(p),

            _ => throw new ArgumentTypeOutOfRangeException(parameterValue)
        };
    }
}
