using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.
    CommentsWithAttachments;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues;

internal static class DocumentStatusTransitionParameterValueInternalFromDomainConverter
{
    internal static DocumentStatusTransitionParameterValueInternal[] FromDomain(DocumentStatusTransitionParameterValue[] parametersValues)
    {
        DocumentStatusTransitionParameterValueInternal[] result = parametersValues.Select(FromDomain).ToArray();

        return result;
    }

    private static DocumentStatusTransitionParameterValueInternal FromDomain(DocumentStatusTransitionParameterValue parameterValue)
    {
        DocumentStatusTransitionParameterValueInternal result = parameterValue switch
        {
            DocumentCommentStatusTransitionParameterValue v =>
                DocumentCommentStatusTransitionParameterValueInternalConverter.FromDomain(v),

            DocumentCommentWithAttachmentsStatusTransitionParameterValue v =>
                DocumentCommentWithAttachmentsStatusTransitionParameterValueInternalConverter.FromDomain(v),

            _ => throw new ArgumentTypeOutOfRangeException(parameterValue)
        };

        return result;
    }
}
