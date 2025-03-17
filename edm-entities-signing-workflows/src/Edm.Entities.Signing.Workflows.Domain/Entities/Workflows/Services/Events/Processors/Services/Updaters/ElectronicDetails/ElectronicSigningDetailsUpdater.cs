using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Events.Processors.Services.Updaters.ElectronicDetails;

internal static class ElectronicSigningDetailsUpdater
{
    internal static void Update(
        SigningElectronicDetails electronicDetails,
        SigningDocument[] documents,
        SigningArchive[] archives)
    {
        Dictionary<Id<Attachment>, Id<Attachment>?> signatoriesByDocumentId =
            electronicDetails.Documents.ToDictionary(d => d.DocumentId, d => d.SignatureId);

        SigningDocument[] updatedDocuments = documents
            .Select(d => SigningDocumentFactory.CreateFrom(d, signatoriesByDocumentId[d.DocumentId]))
            .ToArray();

        electronicDetails.SetDocuments(updatedDocuments);

        electronicDetails.SetArchives(archives);
    }
}
