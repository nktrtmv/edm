using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters.Kinds;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions.Parameters.Kinds;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions.Parameters;

internal static class DocumentStatusTransitionParameterDbConverter
{
    internal static DocumentStatusTransitionParameterDb FromDomain(DocumentStatusTransitionParameter parameter)
    {
        DocumentStatusTransitionParameterKindDb kind = DocumentStatusTransitionParameterKindDbConverter.FromDomain(parameter.Kind);

        var result = new DocumentStatusTransitionParameterDb
        {
            Kind = kind
        };

        return result;
    }

    internal static DocumentStatusTransitionParameter ToDomain(DocumentStatusTransitionParameterDb parameter)
    {
        if (parameter.ValueCase == DocumentStatusTransitionParameterDb.ValueOneofCase.AsCustom) // TODO: OBSOLETE
        {
            return new DocumentStatusTransitionParameter(DocumentStatusTransitionParameterKind.Comment);
        }

        DocumentStatusTransitionParameterKind kind = DocumentStatusTransitionParameterKindDbConverter.ToDomain(parameter.Kind);

        var result = new DocumentStatusTransitionParameter(kind);

        return result;
    }
}
