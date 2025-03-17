using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues.Inheritors.Comments;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.StatusChanged.StatusesTransitionsParametersValues.Comments;

internal static class DocumentCommentStatusTransitionParameterValueDbConverter
{
    internal static DocumentCommentStatusTransitionParameterValueDb FromDomain(DocumentCommentStatusTransitionParameterValue parameterValue)
    {
        var result = new DocumentCommentStatusTransitionParameterValueDb
        {
            Comment = parameterValue.Comment
        };

        return result;
    }

    internal static DocumentCommentStatusTransitionParameterValue ToDomain(
        DocumentCommentStatusTransitionParameterValueDb parameterValue,
        DocumentStatusTransitionParameter[] parameters)
    {
        DocumentStatusTransitionParameter parameter = parameters.Single(p => p.Kind is DocumentStatusTransitionParameterKind.Comment);

        var result = new DocumentCommentStatusTransitionParameterValue(parameter, parameterValue.Comment);

        return result;
    }
}
