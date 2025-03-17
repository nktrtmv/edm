using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Create.Contracts;

public sealed record CreateDocumentTemplateCommandInternal(
    string DomainId,
    string TemplateId,
    string Name,
    string? SystemName,
    string CurrentUser) : IRequest;
