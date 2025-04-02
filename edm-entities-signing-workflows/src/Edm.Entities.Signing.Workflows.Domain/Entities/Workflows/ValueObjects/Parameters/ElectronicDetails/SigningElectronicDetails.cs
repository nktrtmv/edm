using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;

public sealed class SigningElectronicDetails
{
    internal SigningElectronicDetails(Id<User>? signerId, SigningElectronicSummary summary, SigningDocument[] documents, SigningArchive[] archives)
    {
        SignerId = signerId;
        Summary = summary;
        Documents = documents;
        Archives = archives;
    }

    public Id<User>? SignerId { get; private set; }
    public SigningElectronicSummary Summary { get; }
    public SigningDocument[] Documents { get; private set; }
    public SigningArchive[] Archives { get; private set; }

    internal void SetSignerId(Id<User> signerId)
    {
        SignerId = signerId;
    }

    internal void SetDocuments(SigningDocument[] documents)
    {
        Documents = documents;
    }

    internal void SetArchives(SigningArchive[] archives)
    {
        Archives = archives;
    }
}
