using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.UpdateParametersValidators.Helpers.Statuses.Validators;

internal sealed class DocumentStatusExistsValidator
{
    internal DocumentStatusExistsValidator(DocumentStatus[] statuses)
    {
        Statuses = statuses;
    }

    private DocumentStatus[] Statuses { get; }

    internal bool Validate(Id<DocumentStatus> statusId)
    {
        bool statusExists = Statuses.Any(s => s.Id == statusId);

        if (statusExists)
        {
            return true;
        }

        throw new BusinessLogicApplicationException($"Document template does not have status (id: {statusId}).");
    }
}
