using System.ComponentModel.DataAnnotations;

using Edm.DocumentGenerator.Gateway.Presentation.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes.Types;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.Types;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Validators.Conditions.ValueObjects.Targets.Types;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Create;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Create.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Delete;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Delete.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.MigrateAll;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.MigrateAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts.Slim.Filters;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("templates")]
[ApiController]
[Authorize]
public class DocumentTemplatesController(
    UsersService usersService,
    GetDocumentTemplateService getDocumentTemplateService,
    GetAllDocumentTemplatesService getAllDocumentTemplateService,
    CreateDocumentTemplateService createDocumentTemplateService,
    UpdateDocumentTemplateService updateDocumentTemplateService,
    DeleteDocumentTemplateService deleteDocumentTemplateService,
    MigrateAllDocumentsTemplatesService migrateAllDocumentsTemplatesService)
    : ControllerBase
{
    private static readonly Dictionary<DocumentAttributeBffType, string> AttributeTypes = new Dictionary<DocumentAttributeBffType, string>
    {
        { DocumentAttributeBffType.Attachment, "Файл" },
        { DocumentAttributeBffType.Boolean, "Флаг (checkbox)" },
        { DocumentAttributeBffType.Date, "Дата" },
        { DocumentAttributeBffType.Number, "Число" },
        { DocumentAttributeBffType.Reference, "Справочник" },
        { DocumentAttributeBffType.String, "Строка" },
        { DocumentAttributeBffType.Tuple, "Составной атрибут" }
    };

    private static readonly Dictionary<ConditionTargetBffType, string> DocumentValidatorConditionTargetTypes = new Dictionary<ConditionTargetBffType, string>
    {
        { ConditionTargetBffType.DocumentAttribute, "Атрибут" },
        { ConditionTargetBffType.Number, "Число" },
        { ConditionTargetBffType.Boolean, "Флаг (checkbox)" },
        { ConditionTargetBffType.DateTime, "Дата и Время" },
        { ConditionTargetBffType.String, "Строка" },
        { ConditionTargetBffType.Reference, "Значение справочника" }
    };

    private static readonly Dictionary<ConditionBffType, string> DocumentValidatorConditionTypes = new Dictionary<ConditionBffType, string>
    {
        { ConditionBffType.Exists, "Не пустой" },
        { ConditionBffType.ExistsAny, "Хотя бы один не пустой" },
        { ConditionBffType.ExistsWithReferencePrecondition, "Не пустой если атрибут равен" },
        { ConditionBffType.Empty, "Пустой" },
        { ConditionBffType.Regex, "Совпадает с выражением" },
        { ConditionBffType.SumEquals, "Сумма равна" },
        { ConditionBffType.Compare, "Сравнить" },
        { ConditionBffType.CompareReference, "Совпадает с выражением справочника" }
    };

    [HttpPost(nameof(GetAttributeTypes), Name = nameof(GetAttributeTypes))]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentAttributeBffType>>> GetAttributeTypes(CancellationToken cancellationToken)
    {
        CollectionQueryResponse<EnumMapBff<DocumentAttributeBffType>> response = EnumMapBffConverter.ConvertToResponse(AttributeTypes);

        return Task.FromResult(response);
    }

    [HttpGet(nameof(GetDocumentValidatorConditionTargetTypes), Name = nameof(GetDocumentValidatorConditionTargetTypes))]
    public Task<CollectionQueryResponse<EnumMapBff<ConditionTargetBffType>>> GetDocumentValidatorConditionTargetTypes(CancellationToken cancellationToken)
    {
        CollectionQueryResponse<EnumMapBff<ConditionTargetBffType>> response = EnumMapBffConverter.ConvertToResponse(DocumentValidatorConditionTargetTypes);

        return Task.FromResult(response);
    }

    [HttpGet(nameof(GetDocumentValidatorConditionTypes), Name = nameof(GetDocumentValidatorConditionTypes))]
    public Task<CollectionQueryResponse<EnumMapBff<ConditionBffType>>> GetDocumentValidatorConditionTypes(CancellationToken cancellationToken)
    {
        CollectionQueryResponse<EnumMapBff<ConditionBffType>> response = EnumMapBffConverter.ConvertToResponse(DocumentValidatorConditionTypes);

        return Task.FromResult(response);
    }

    [HttpPost(nameof(GetDocumentTemplate), Name = nameof(GetDocumentTemplate))]
    public async Task<GetDocumentTemplateQueryBffResponse> GetDocumentTemplate(GetDocumentTemplateQueryBff query, CancellationToken cancellationToken)
    {
        var response = await getDocumentTemplateService.Get(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetAllDocumentTemplates), Name = nameof(GetAllDocumentTemplates))]
    public async Task<GetAllDocumentTemplatesQueryBffResponse> GetAllDocumentTemplates(
        [FromQuery] int skip,
        [FromQuery] int limit,
        [FromQuery] DocumentsTemplatesFilteringParametersDto filteringParameters,
        [FromQuery] [Required] string domainId,
        CancellationToken cancellationToken = default)
    {
        var response = await getAllDocumentTemplateService.GetAll(
            domainId,
            skip,
            limit,
            filteringParameters,
            cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetAllReadyForDocumentCreationDocumentTemplates), Name = nameof(GetAllReadyForDocumentCreationDocumentTemplates))]
    public async Task<GetAllReadyForDocumentCreationDocumentTemplatesQueryBffResponse> GetAllReadyForDocumentCreationDocumentTemplates(
        [FromQuery] int skip,
        [FromQuery] int limit,
        [FromQuery] DocumentsTemplatesReadyForDocumentCreationFilteringParametersDto filteringParameters,
        [FromQuery] [Required] string domainId,
        CancellationToken cancellationToken = default)
    {
        var filtering = new DocumentsTemplatesFilteringParametersDto
        {
            Status = "ReadyForDocumentCreation",
            Query = filteringParameters.Query
        };

        var response = await GetAllDocumentTemplates(skip, limit, filtering, domainId, cancellationToken);

        var result = new GetAllReadyForDocumentCreationDocumentTemplatesQueryBffResponse
        {
            Templates = response.Templates
        };

        return result;
    }

    [HttpPost(nameof(CreateDocumentTemplate), Name = nameof(CreateDocumentTemplate))]
    public async Task<CreateDocumentTemplateCommandBffResponse> CreateDocumentTemplate(CreateDocumentTemplateCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await createDocumentTemplateService.Create(command, user, cancellationToken);

        return response;
    }

    [HttpPost(nameof(UpdateDocumentTemplate), Name = nameof(UpdateDocumentTemplate))]
    public async Task<UpdateDocumentTemplateCommandBffResponse> UpdateDocumentTemplate(UpdateDocumentTemplateCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await updateDocumentTemplateService.Update(command, user, cancellationToken);

        return response;
    }

    [HttpPost(nameof(DeleteDocumentTemplate), Name = nameof(DeleteDocumentTemplate))]
    public async Task<DeleteDocumentTemplateCommandBffResponse> DeleteDocumentTemplate(DeleteDocumentTemplateCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await deleteDocumentTemplateService.Delete(command, user, cancellationToken);

        return response;
    }

    [HttpPost(nameof(MigrateAllTemplates), Name = nameof(MigrateAllTemplates))]
    public async Task<MigrateAllDocumentsTemplatesCommandBffResponse> MigrateAllTemplates(
        MigrateAllDocumentsTemplatesCommandBffCommand command,
        CancellationToken cancellationToken)
    {
        var response = await migrateAllDocumentsTemplatesService.MigrateAll(command, cancellationToken);

        return response;
    }
}
