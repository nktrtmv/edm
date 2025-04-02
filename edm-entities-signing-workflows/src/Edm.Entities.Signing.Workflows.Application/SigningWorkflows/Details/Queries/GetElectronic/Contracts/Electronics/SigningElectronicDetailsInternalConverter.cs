using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics;

internal static class SigningElectronicDetailsInternalConverter
{
    internal static SigningElectronicDetailsInternal FromDomain(SigningElectronicDetails details)
    {
        SigningArchiveInternal[] archives =
            details.Archives.Select(SigningArchivesInternalConverter.FromDomain).ToArray();

        SigningDocumentInternal[] documents =
            details.Documents.Select(SigningDocumentInternalConverter.FromDomain).ToArray();

        var result = new SigningElectronicDetailsInternal(archives, documents);

        return result;
    }
}
