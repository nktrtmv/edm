using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Documents;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Entities;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Parties;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Summaries;
using Edm.Entities.Signing.Workflows.ExternalServices.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts;

public sealed class SendSigningEdxDocumentsCommandExternal
{
    public SendSigningEdxDocumentsCommandExternal(
        Id<SigningExternal> signingId,
        Id<UserExternal>? signerId,
        SigningEdxEntityExternal entity,
        SigningEdxSummaryExternal summary,
        SigningEdxPartiesExternal parties,
        SigningEdxDocumentExternal[] documents)
    {
        SigningId = signingId;
        SignerId = signerId;
        Entity = entity;
        Summary = summary;
        Parties = parties;
        Documents = documents;
    }

    public Id<SigningExternal> SigningId { get; }
    public Id<UserExternal>? SignerId { get; }
    public SigningEdxEntityExternal Entity { get; }
    public SigningEdxSummaryExternal Summary { get; }
    public SigningEdxPartiesExternal Parties { get; }
    public SigningEdxDocumentExternal[] Documents { get; }
}
