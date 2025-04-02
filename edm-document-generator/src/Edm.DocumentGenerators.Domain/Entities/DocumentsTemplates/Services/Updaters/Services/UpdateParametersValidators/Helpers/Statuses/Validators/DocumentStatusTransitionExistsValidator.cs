using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Statuses.Validators;

internal sealed class DocumentStatusTransitionExistsValidator
{
    public DocumentStatusTransitionExistsValidator(DocumentStatusTransition[] statusTransitions)
    {
        StatusTransitions = statusTransitions;
    }

    private DocumentStatusTransition[] StatusTransitions { get; }

    internal bool Validate(Id<DocumentStatus> fromId, Id<DocumentStatus> toId)
    {
        bool transitionExists = StatusTransitions.Any(t => t.From.Id == fromId && t.To.Id == toId);

        if (transitionExists)
        {
            return true;
        }

        throw new BusinessLogicApplicationException($"Document template does not have transition from status (id: {fromId}) to status (id: {toId}).");
    }
}
