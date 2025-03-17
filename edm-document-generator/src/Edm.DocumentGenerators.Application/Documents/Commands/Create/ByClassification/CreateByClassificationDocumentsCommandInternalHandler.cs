using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.Classifications;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Contracts;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Filters;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Searchers;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Validators;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.Services.Creators;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification;

[UsedImplicitly]
internal sealed class CreateByClassificationDocumentsCommandInternalHandler
    : IRequestHandler<CreateByClassificationDocumentsCommandInternal, CreateByClassificationDocumentsCommandInternalResponse>
{
    public CreateByClassificationDocumentsCommandInternalHandler(
        TemplatesIdsByClassificationSearcherService templatesIdsByClassificationSearcher,
        TemplatesIdsByReadyForDocumentCreationFilterService templatesIdsByReadyForDocumentCreationFilter,
        DocumentsCreatorService creator)
    {
        TemplatesIdsByClassificationSearcher = templatesIdsByClassificationSearcher;
        TemplatesIdsByReadyForDocumentCreationFilter = templatesIdsByReadyForDocumentCreationFilter;
        Creator = creator;
    }

    private TemplatesIdsByClassificationSearcherService TemplatesIdsByClassificationSearcher { get; }
    private TemplatesIdsByReadyForDocumentCreationFilterService TemplatesIdsByReadyForDocumentCreationFilter { get; }
    private DocumentsCreatorService Creator { get; }

    public async Task<CreateByClassificationDocumentsCommandInternalResponse> Handle(
        CreateByClassificationDocumentsCommandInternal request,
        CancellationToken cancellationToken)
    {
        if (request.DomainId != DomainId.Contracts)
        {
            throw new BusinessLogicApplicationException("Only contracts domain allowed to use create by classification method");
        }

        DocumentClassification? classification = DocumentClassificationInternalConverter.ToDomain(request.Classification);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        Id<DocumentTemplate>[] potentialTemplatesIds = await TemplatesIdsByClassificationSearcher.Search(classification, cancellationToken);

        DomainId domainId = DomainId.Parse(request.DomainId);
        Id<DocumentTemplate>[] readyForDocumentCreationTemplatesIds =
            await TemplatesIdsByReadyForDocumentCreationFilter.Filter(domainId, potentialTemplatesIds, cancellationToken);

        CreateByClassificationBusinessLogicValidator.Validate(classification, readyForDocumentCreationTemplatesIds);

        Id<DocumentTemplate> templateId = readyForDocumentCreationTemplatesIds.Single();

        Id<DocumentInternal> documentId = await Creator.Create(domainId, templateId, currentUserId, classification, cancellationToken);

        var response = new CreateByClassificationDocumentsCommandInternalResponse(documentId.Value);

        return response;
    }
}
