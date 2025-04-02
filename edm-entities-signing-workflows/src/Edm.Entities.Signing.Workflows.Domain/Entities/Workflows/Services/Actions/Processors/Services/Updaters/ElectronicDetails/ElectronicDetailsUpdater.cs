using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.ElectronicDetails.Validators;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.ElectronicDetails;

internal static class ElectronicDetailsUpdater
{
    internal static void Update(SigningActionContext context, Dictionary<Id<Attachment>, Id<Attachment>>? documentsWithSignatures)
    {
        SigningElectronicDetails signingElectronicDetails = context.Workflow.Parameters.ElectronicDetails!;

        if (documentsWithSignatures is null)
        {
            return;
        }

        AllElectronicDocumentsHasCorrespondedSignatureValidator.Validate(signingElectronicDetails.Documents, documentsWithSignatures);

        SigningDocument[] documents = documentsWithSignatures.Select(SigningDocumentFactory.CreateFrom).ToArray();

        signingElectronicDetails.SetDocuments(documents);
        signingElectronicDetails.SetSignerId(context.CurrentUserId);
    }
}
