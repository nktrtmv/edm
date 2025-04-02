using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Delete;

public sealed class DeleteDocumentsCommandHandlerInternal(IDocumentsRepository documentsRepository)
    : IRequestHandler<DeleteDocumentsCommandInternal>
{
    public async Task Handle(DeleteDocumentsCommandInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        HashSet<Id<Document>>? ids = request.DocumentIds.Select(IdConverterFrom<Document>.FromString).ToHashSet();

        await documentsRepository.DeleteByIds(domainId, ids, cancellationToken);
    }
}
