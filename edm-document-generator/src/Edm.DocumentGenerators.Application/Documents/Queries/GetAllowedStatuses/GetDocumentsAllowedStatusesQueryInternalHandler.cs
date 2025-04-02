using Edm.DocumentGenerators.Application.Documents.Queries.GetAllowedStatuses.Contracts;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.AllowedStatuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.GetAllowedStatuses;

[UsedImplicitly]
internal sealed class GetDocumentsAllowedStatusesQueryInternalHandler(DocumentsFacade facade)
    : IRequestHandler<GetDocumentsAllowedStatusesQueryInternal, GetDocumentsAllowedStatusesQueryResponseInternal>
{
    public async Task<GetDocumentsAllowedStatusesQueryResponseInternal> Handle(GetDocumentsAllowedStatusesQueryInternal request, CancellationToken cancellationToken)
    {
        Id<Document>[] documentsIds = request.DocumentsIds.Select(IdConverterFrom<Document>.FromString).ToArray();

        Document[] documents = await facade.GetAll(documentsIds, true, cancellationToken);

        (HashSet<DocumentStatus>? statuses, BusinessLogicApplicationException? exception) = DocumentsAllowedStatusesDetector.Detect(documents);

        if (exception is not null)
        {
            throw exception;
        }

        GetDocumentsAllowedStatusesQueryResponseInternal? result = GetDocumentsAllowedStatusesQueryResponseInternalConverter.FromDomain(statuses);

        return result;
    }
}
