using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Services.Validators.Changes.StatusChanges.TransitionParameters.Comments;

internal static class CommentInDocumentStatusTransitionParameterIsFilledValidator
{
    internal static None Validate(DocumentCommentStatusTransitionParameterValue parameterValue)
    {
        if (parameterValue.Parameter.Kind is not DocumentStatusTransitionParameterKind.Comment)
        {
            throw new ArgumentValueOutOfRangeException(parameterValue.Parameter.Kind);
        }

        if (!string.IsNullOrWhiteSpace(parameterValue.Comment))
        {
            return default;
        }

        throw new BusinessLogicApplicationException($"Comment in status transition parameter should be filled (kind: {parameterValue.Parameter.Kind}).");
    }
}
