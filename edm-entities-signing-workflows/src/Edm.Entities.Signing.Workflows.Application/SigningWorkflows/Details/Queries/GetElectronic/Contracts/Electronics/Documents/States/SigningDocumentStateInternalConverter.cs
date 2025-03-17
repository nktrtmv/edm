using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States.Statuses;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States;

internal static class SigningDocumentStateInternalConverter
{
    internal static SigningDocumentStateInternal FromDomain(SigningDocumentState state)
    {
        SigningDocumentStatusInternal status = SigningDocumentStatusInternalConverter.FromDomain(state.Status);

        UtcDateTime<SigningDocumentInternal> statusChangedAt = UtcDateTimeConverterFrom<SigningDocumentInternal>.From(state.StatusChangedAt);

        var result = new SigningDocumentStateInternal(status, state.StatusDescription, statusChangedAt);

        return result;
    }
}
