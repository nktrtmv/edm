using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Updaters.ElectronicDetails.Validators;

internal static class AllElectronicDocumentsHasCorrespondedSignatureValidator
{
    internal static void Validate(SigningDocument[] documents, Dictionary<Id<Attachment>, Id<Attachment>> documentsWithSignatures)
    {
        if (documents.Length != documentsWithSignatures.Count)
        {
            throw new ApplicationException($"Number of signatures {documentsWithSignatures.Count} shall be equal to the number of documents {documents.Length}.");
        }

        foreach (SigningDocument document in documents)
        {
            if (!documentsWithSignatures.ContainsKey(document.DocumentId))
            {
                throw new ApplicationException($"Signatures for document (id: {document.DocumentId}) is not found.");
            }
        }
    }
}
