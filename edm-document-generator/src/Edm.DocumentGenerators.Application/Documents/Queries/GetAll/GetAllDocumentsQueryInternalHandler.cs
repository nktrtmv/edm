using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Application.Documents.Queries.GetAll.Contracts;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllDocumentsQueryInternalHandler(IDocumentsRepository documentsRepository)
    : IRequestHandler<GetAllDocumentsQueryInternal, DocumentDetailedInternal[]>
{
    public async Task<DocumentDetailedInternal[]> Handle(GetAllDocumentsQueryInternal request, CancellationToken cancellationToken)
    {
        HashSet<Id<Document>>? documentsIds = request.DocumentsIds.Select(IdConverterFrom<Document>.From).ToHashSet();

        Document[] documents = await documentsRepository.Search(documentsIds, cancellationToken);

        DocumentDetailedInternal[] result = documents.Select(d => DocumentDetailedInternalFromDomainConverter.FromDomain(d, null)).ToArray();

        return result;
    }
}
