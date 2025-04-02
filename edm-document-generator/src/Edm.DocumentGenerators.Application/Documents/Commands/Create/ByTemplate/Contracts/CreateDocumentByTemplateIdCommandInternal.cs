using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByTemplate.Contracts;

public sealed record CreateDocumentByTemplateIdCommandInternal(
    string DomainId,
    string TemplateId,
    string CurrentUserId)
    : IRequest<CreateDocumentByTemplateIdCommandInternalResponse>;
