using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Documents.States.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Documents.States;

internal static class SigningDocumentStateDbConverter
{
    internal static SigningDocumentStateDb FromDomain(SigningDocumentState state)
    {
        SigningDocumentStatusDb status = SigningDocumentStatusDbConverter.FromDomain(state.Status);

        Timestamp statusChangedAt = UtcDateTimeConverterTo.ToTimeStamp(state.StatusChangedAt);

        var result = new SigningDocumentStateDb
        {
            Status = status,
            StatusDescription = state.StatusDescription,
            StatusChangedAt = statusChangedAt
        };

        return result;
    }

    internal static SigningDocumentState ToDomain(SigningDocumentStateDb state)
    {
        SigningDocumentStatus status =
            SigningDocumentStatusDbConverter.ToDomain(state.Status);

        UtcDateTime<SigningDocument> statusChangedAt =
            UtcDateTimeConverterFrom<SigningDocument>.FromTimestamp(state.StatusChangedAt);

        SigningDocumentState result = SigningDocumentStateFactory.CreateFromDb(status, state.StatusDescription, statusChangedAt);

        return result;
    }
}
