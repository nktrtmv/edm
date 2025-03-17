using Edm.DocumentGenerator.Gateway.Core.Contracts.Audit.Briefs;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts.Slim;

public sealed class DocumentTemplateSlimBff
{
    public required string Id { get; init; }

    public required string DomainId { get; init; }

    public required string Name { get; init; }

    public required DocumentTemplateStatusBff Status { get; init; }

    public required AuditBriefBff Audit { get; set; }
}
