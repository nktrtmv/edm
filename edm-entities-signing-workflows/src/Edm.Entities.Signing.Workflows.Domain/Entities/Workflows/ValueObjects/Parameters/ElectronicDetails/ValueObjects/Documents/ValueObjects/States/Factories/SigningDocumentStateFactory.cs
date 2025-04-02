using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.Factories;

public static class SigningDocumentStateFactory
{
    internal static SigningDocumentState CreateFrom(SigningDocumentStatus status)
    {
        var statusDescription = string.Empty;

        UtcDateTime<SigningDocument> statusChangedAt = UtcDateTime<SigningDocument>.Now;

        SigningDocumentState result = CreateFromDb(status, statusDescription, statusChangedAt);

        return result;
    }

    public static SigningDocumentState CreateFrom(
        SigningDocumentStatus status,
        string statusDescription,
        UtcDateTime<SigningDocument> statusChangedAt)
    {
        SigningDocumentState result = CreateFromDb(status, statusDescription, statusChangedAt);

        return result;
    }

    public static SigningDocumentState CreateFromDb(
        SigningDocumentStatus status,
        string statusDescription,
        UtcDateTime<SigningDocument> statusChangedAt)
    {
        var result = new SigningDocumentState(status, statusDescription, statusChangedAt);

        return result;
    }
}
