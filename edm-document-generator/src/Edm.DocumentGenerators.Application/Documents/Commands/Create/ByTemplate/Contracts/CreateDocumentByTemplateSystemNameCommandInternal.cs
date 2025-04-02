using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByTemplate.Contracts;

public sealed record CreateDocumentByTemplateSystemNameCommandInternal(
    string DomainId,
    string SystemName,
    string CurrentUserId)
    : IRequest<CreateDocumentByTemplateSystemNameCommandInternalResponse>;
