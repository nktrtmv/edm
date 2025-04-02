using Edm.DocumentGenerator.Gateway.Presentation.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Stages;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByClassification;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByClassification.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByTemplate;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByTemplate.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Delete;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.ProcessAll;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.ProcessAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.GetDocumentStages;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Count;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Count.Contracts;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

using Polly;
using Polly.Retry;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("documents")]
[ApiController]
[Authorize]
public class DocumentsController(
    CreateDocumentByTemplateService createDocumentByTemplateService,
    CreateDocumentByClassificationService createDocumentByClassificationService,
    UpdateDocumentService updateDocumentService,
    GetDocumentService getDocumentService,
    GetAllDocumentsService getAllDocumentsService,
    GetDocumentsCountService getGetDocumentsCountService,
    ValidateDocumentService validateDocumentService,
    ProcessAllDocumentsService processAllDocumentsService,
    DeleteDocumentsService deleteDocumentsService,
    UsersService usersService) : ControllerBase
{
    private readonly AsyncRetryPolicy _policy = Policy.Handle<Exception>()
        .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2));

    [HttpPost(nameof(GetDocumentStageTypes), Name = nameof(GetDocumentStageTypes))]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentStageTypeBff>>> GetDocumentStageTypes(CancellationToken cancellationToken)
    {
        var response = EnumMapBffConverter.ConvertToResponse(GetDocumentStagesTypesService.DocumentStagesTypes);

        return Task.FromResult(response);
    }

    [HttpPost(nameof(CreateDocumentByTemplate), Name = nameof(CreateDocumentByTemplate))]
    public async Task<CreateDocumentByTemplateIdCommandBffResponse> CreateDocumentByTemplate(
        CreateDocumentByTemplateIdCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await createDocumentByTemplateService.Create(command, user, cancellationToken);

        return response;
    }

    [HttpPost(nameof(DeleteDocumentsByRoleValueContains), Name = nameof(DeleteDocumentsByRoleValueContains))]
    public async Task DeleteDocumentsByRoleValueContains(string domainId, string registryRole, string match, CancellationToken cancellationToken)
    {
        await deleteDocumentsService.DeleteDocumentsByRoleValueContains(domainId, registryRole, match, cancellationToken);
    }

    [HttpPost(nameof(CreateDocumentByClassification), Name = nameof(CreateDocumentByClassification))]
    public async Task<CreateByClassificationCommandBffResponse> CreateDocumentByClassification(
        CreateByClassificationCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await createDocumentByClassificationService.Create(command, user, cancellationToken);

        return response;
    }

    [HttpPost(nameof(UpdateDocument), Name = nameof(UpdateDocument))]
    public async Task<UpdateDocumentCommandBffResponse> UpdateDocument(UpdateDocumentCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await updateDocumentService.Update(command, user, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetDocument), Name = nameof(GetDocument))]
    public async Task<GetDocumentQueryBffResponse> GetDocument(GetDocumentQueryBff query, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await _policy.ExecuteAsync(async () => await getDocumentService.GetEnriched(query, user, cancellationToken));

        return response;
    }

    [HttpPost(nameof(GetAllDocuments), Name = nameof(GetAllDocuments))]
    public async Task<GetAllDocumentsQueryBffResponse> GetAllDocuments(
        GetAllDocumentsQueryBff query,
        [FromQuery] int skip,
        [FromQuery] int limit,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await getAllDocumentsService.GetAll(user, query, skip, limit, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetDocumentsCount), Name = nameof(GetDocumentsCount))]
    public async Task<GetDocumentsCountResponseBff> GetDocumentsCount(
        GetDocumentsCountQueryBff query,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await getGetDocumentsCountService.Count(user, query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(ValidateDocument), Name = nameof(ValidateDocument))]
    public async Task<ValidateDocumentQueryBffResponse> ValidateDocument(ValidateDocumentQueryBff command, CancellationToken cancellationToken)
    {
        var currentUser = usersService.GetCurrentUser();

        var response = await validateDocumentService.Validate(command, currentUser, cancellationToken);

        return response;
    }

    [HttpPost(nameof(ProcessAllDocuments), Name = nameof(ProcessAllDocuments))]
    public async Task<ProcessAllDocumentsCommandBffResponse> ProcessAllDocuments(ProcessAllDocumentsCommandBff commandBff, CancellationToken cancellationToken)
    {
        var response = await processAllDocumentsService.ProcessAll(commandBff.DomainId, cancellationToken);

        return response;
    }
}
