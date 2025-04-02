using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Edm.Document.Searcher.Application.Documents.Command;

public sealed class DeleteDocumentsCommandHandlerInternal(IWebHostEnvironment webHostEnvironment, ISearchDocumentsRepository searchDocumentsRepository)
    : IRequestHandler<DeleteDocumentsCommandInternal>
{
    public async Task Handle(DeleteDocumentsCommandInternal request, CancellationToken cancellationToken)
    {
        if (webHostEnvironment.IsProduction())
        {
            throw new ApplicationException("Only for non production qa documents");
        }

        var domainId = DomainId.Parse(request.DomainId);
        var documentIds = request.DocumentIds.Select(IdConverterFrom<SearchDocument>.FromString).ToHashSet();
        await searchDocumentsRepository.DeleteByIds(domainId, documentIds, cancellationToken);
    }
}
