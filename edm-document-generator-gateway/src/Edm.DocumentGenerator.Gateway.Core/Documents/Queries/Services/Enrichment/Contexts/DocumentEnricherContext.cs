using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Enrichers;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment.Contexts;

internal sealed class DocumentEnricherContext(DocumentDetailedDto document, UserBff user, DocumentWorkflows workflows) : EnrichersContext
{
    public DocumentDetailedDto Document { get; } = document;
    public UserBff User { get; } = user;
    public DocumentWorkflows Workflows { get; } = workflows;
}
