using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Documents.States.Statuses;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts.Converters.Documents.States;

internal static class SigningEdxDocumentStateDtoConverter
{
    internal static SigningDocumentState ToDomain(SigningEdxDocumentStateDto state)
    {
        SigningDocumentStatus status = SigningEdxDocumentStatusDtoConverter.ToDomain(state.Status);

        UtcDateTime<SigningDocument> statusChangedAt = UtcDateTimeConverterFrom<SigningDocument>.FromTimestamp(state.StatusChangedAt);

        SigningDocumentState result = SigningDocumentStateFactory.CreateFrom(status, state.StatusDescription, statusChangedAt);

        return result;
    }
}
