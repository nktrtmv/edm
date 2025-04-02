using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.Factories;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Archives;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Summaries;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Archives;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Documents;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails.Summaries;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails;

internal static class SigningElectronicDetailsDbConverter
{
    internal static SigningElectronicDetailsDb FromDomain(SigningElectronicDetails details)
    {
        string? signerId = NullableConverter.Convert(details.SignerId, IdConverterTo.ToString);

        SigningElectronicSummaryDb summary =
            SigningElectronicSummaryDbConverter.FromDomain(details.Summary);

        SigningDocumentDb[] documents =
            details.Documents.Select(SigningDocumentDbConverter.FromDomain).ToArray();

        SigningArchiveDb[] archives =
            details.Archives.Select(SigningArchiveDbConverter.FromDomain).ToArray();

        var result = new SigningElectronicDetailsDb
        {
            SignerId = signerId,
            Summary = summary,
            Documents = { documents },
            Archives = { archives },
        };

        return result;
    }

    internal static SigningElectronicDetails ToDomain(SigningElectronicDetailsDb details)
    {
        Id<User>? signerId = NullableConverter.Convert(details.SignerId, IdConverterFrom<User>.FromString);

        SigningElectronicSummary summary =
            SigningElectronicSummaryDbConverter.ToDomain(details.Summary);

        SigningDocument[] documents =
            details.Documents.Select(SigningDocumentDbConverter.ToDomain).ToArray();

        SigningArchive[] archives =
            details.Archives.Select(SigningArchiveDbConverter.ToDomain).ToArray();

        SigningElectronicDetails result =
            SigningElectronicDetailsFactory.CreateFromDb(signerId, summary, documents, archives);

        return result;
    }
}
