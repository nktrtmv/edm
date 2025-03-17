using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries.Factories;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.Factories;

public static class SigningElectronicDetailsFactory
{
    public static SigningElectronicDetails CreateFrom(string entityName, string entityNumber, UtcDateTime<Entity> entityDate, Id<Attachment>[] documentsIds)
    {
        SigningElectronicSummary summary = SigningElectronicSummaryFactory.CreateFrom(entityName, entityNumber, entityDate);

        SigningDocument[] documents = documentsIds.Select(SigningDocumentFactory.CreateFrom).ToArray();

        SigningElectronicDetails result = CreateFromDb(null, summary, documents);

        return result;
    }

    public static SigningElectronicDetails CreateFromDb(Id<User>? signerId, SigningElectronicSummary summary, SigningDocument[] documents, params SigningArchive[] archives)
    {
        var result = new SigningElectronicDetails(signerId, summary, documents, archives);

        return result;
    }
}
