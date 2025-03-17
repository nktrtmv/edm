using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.Tech.Commands.ChangeDocumentStatus.Contracts;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.Factories;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Tech.Commands.ChangeDocumentStatus;

[UsedImplicitly]
internal sealed class ChangeDocumentStatusTechCommandInternalHandler(DocumentsFacade documents, IRoleAdapter roleAdapter)
    : IRequestHandler<ChangeDocumentStatusTechCommandInternal>
{
    public async Task Handle(ChangeDocumentStatusTechCommandInternal request, CancellationToken cancellationToken)
    {
        Id<Document> documentId = IdConverterFrom<Document>.FromString(request.DocumentId);

        Document? document = await documents.GetRequired(documentId, true, cancellationToken);

        Id<DocumentStatus> currentStatusId = IdConverterFrom<DocumentStatus>.FromString(request.CurrentStatusId);

        if (document.Status.Id != currentStatusId)
        {
            throw new BusinessLogicApplicationException("The specified status is not current");
        }

        Id<DocumentStatus> statusToId = IdConverterFrom<DocumentStatus>.FromString(request.StatusToId);

        Id<User> userId = IdConverterFrom<User>.FromString(request.UserId);

        DocumentStatusTransition? transition = DocumentStatusTransitionFactory.CreateManualTransition(document, currentStatusId, statusToId);

        DocumentUpdateParameters? parameters = DocumentUpdateParametersFactory.Create(transition);

        TryFinishWorkflows(document);

        DocumentUpdater.Update(roleAdapter, document, userId, parameters);

        await documents.Upsert(document, cancellationToken);
    }

    private static void TryFinishWorkflows(Document document)
    {
        if (document.Status.Type is DocumentStatusType.Signing)
        {
            document.SigningData.Workflows.Last().SetStatus(DocumentSigningWorkflowStatus.Finished);
        }

        if (document.Status.Type is DocumentStatusType.Approval)
        {
            throw new BusinessLogicApplicationException("Can't force move status from approval");
        }
    }
}
