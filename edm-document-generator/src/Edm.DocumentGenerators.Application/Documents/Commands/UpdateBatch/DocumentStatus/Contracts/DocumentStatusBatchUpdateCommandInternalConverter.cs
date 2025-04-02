using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentStatus.Contracts;

internal static class DocumentStatusBatchUpdateCommandInternalConverter
{
    public static DocumentUpdateParameters ToDomain(Document document, string newStatusId)
    {
        Id<Domain.ValueObjects.Statuses.DocumentStatus> toStatusId = IdConverterFrom<Domain.ValueObjects.Statuses.DocumentStatus>.FromString(newStatusId);

        DocumentStatusTransition transition = document.StatusStateMachine.GetRequiredTransition(document.Status.Id, toStatusId);

        DocumentUpdateParameters result = DocumentUpdateParametersFactory.Create(transition);

        return result;
    }
}
