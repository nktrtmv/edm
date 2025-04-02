using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.MigrateAll.Contracts;

public sealed record MigrateAllDocumentsTemplatesCommandInternal(string DomainId) : IRequest;
