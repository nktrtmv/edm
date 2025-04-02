namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update.Contracts;

public sealed class UpdateDocumentTemplateCommandBff
{
    public required DocumentTemplateBareBff Template { get; init; }
}
