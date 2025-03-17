using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters.Documents;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters.Entites;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters.Parties;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters.Summaries;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendDocumentsToEdx;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Documents;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Entities;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Parties;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Summaries;
using Edm.Entities.Signing.Workflows.ExternalServices.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters;

internal static class SendSigningEdxDocumentsCommandExternalConverter
{
    internal static SendSigningEdxDocumentsCommandExternal FromDomain(SigningWorkflow workflow, SendDocumentsToEdxSigningApplicationEvent _)
    {
        Id<SigningExternal> signingId = IdConverterFrom<SigningExternal>.From(workflow.Id);

        Id<UserExternal>? signerId = NullableConverter.Convert(workflow.Parameters.ElectronicDetails?.SignerId, IdConverterFrom<UserExternal>.From);

        SigningEdxEntityExternal entity = SigningEdxEntityExternalConverter.FromDomain(workflow);

        SigningEdxSummaryExternal summary = SigningEdxSummaryExternalConverter.FromDomain(workflow.Parameters.ElectronicDetails!.Summary);

        SigningEdxPartiesExternal parties = SigningEdxPartiesExternalConverter.FromDomain(workflow.State);

        SigningEdxDocumentExternal[] documents =
            workflow.Parameters.ElectronicDetails!.Documents.Select(SigningEdxDocumentExternalExternalConverter.FromDomain).ToArray();

        var result = new SendSigningEdxDocumentsCommandExternal(signingId, signerId, entity, summary, parties, documents);

        return result;
    }
}
