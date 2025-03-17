using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesErrors;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Factories;

public static class DocumentUpdateParametersFactory
{
    public static DocumentUpdateParameters Create(DocumentStatusTransition statusTransition)
    {
        if (statusTransition.Parameters.Any())
        {
            throw new BusinessLogicApplicationException(
                $"Attempt to create an Update change from transition (id: {statusTransition.Id}) without transition parameters values.");
        }

        var statusChange = new DocumentStatusChange(statusTransition);

        DocumentUpdateParameters result = Create(statusChange, null);

        return result;
    }

    public static DocumentUpdateParameters Create(
        DocumentStatusChange? statusChange,
        DocumentAttributesChange? attributesChange,
        DocumentAttributeError[]? attributesErrors = null,
        string[]? documentErrors = null)
    {
        var result = new DocumentUpdateParameters(statusChange, attributesChange, attributesErrors, documentErrors);

        return result;
    }
}
