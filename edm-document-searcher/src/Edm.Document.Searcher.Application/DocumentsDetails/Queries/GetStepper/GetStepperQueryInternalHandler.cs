using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Steppers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper;


[UsedImplicitly]
internal sealed class GetStepperQueryInternalHandler(GetDocumentStepperService getDocumentStepperService)
    : IRequestHandler<GetStepperQueryInternal, GetStepperQueryResponseInternal>
{
    public async Task<GetStepperQueryResponseInternal> Handle(GetStepperQueryInternal request, CancellationToken cancellationToken)
    {
        var documentId = IdConverterFrom<DocumentExternal>.FromString(request.Id);
        var domainId = DomainId.Parse(request.DomainId);

        var stepper = await getDocumentStepperService.GetDocumentStepper(documentId, domainId, cancellationToken);

        var result = new GetStepperQueryResponseInternal(stepper.Steps, request.Id, request.DomainId);

        return result;
    }
}
