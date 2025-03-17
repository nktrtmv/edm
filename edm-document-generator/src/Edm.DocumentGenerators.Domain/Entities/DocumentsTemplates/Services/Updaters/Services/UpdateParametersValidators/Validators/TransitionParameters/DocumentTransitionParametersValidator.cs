using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Validators.TransitionParameters;

internal static class DocumentTransitionParametersValidator
{
    private static readonly DocumentStatusType[] StatusTypesFromWithForbiddenTransitionParameters =
    [
        DocumentStatusType.Approval
    ];

    public static void Validate(DocumentStatusTransition[] statusTransitions)
    {
        foreach (DocumentStatusTransition statusTransition in statusTransitions)
        {
            bool parameterAreForbidden = StatusTypesFromWithForbiddenTransitionParameters.Contains(statusTransition.From.Type) &&
                statusTransition.Parameters.Length != 0;

            if (parameterAreForbidden)
            {
                throw new BusinessLogicApplicationException(
                    $"Параметры перехода {statusTransition.DisplayName} ({statusTransition.Id}) запрещены из статуса {statusTransition.From.DisplayName} ({statusTransition.From.Id})");
            }
        }
    }
}
