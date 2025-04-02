using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Delete.Contracts;

public sealed record DeleteDocumentTemplateCommandInternal(string DomainId, string Id, string CurrentUser) : IRequest;
