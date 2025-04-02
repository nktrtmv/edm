using Edm.DocumentGenerator.Gateway.Presentation.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetNewReferenceTypeId;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetNewReferenceTypeId.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch.Contracts;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("references")]
[ApiController]
[Authorize]
public class ReferencesController(
    GetReferencesTypesService getReferencesTypesService,
    GetReferencesTypeValuesSearchService getReferencesTypeValuesSearchService,
    GetAllReferenceService getAllReferencesService,
    GetReferenceService getReferenceService,
    CreateReferenceService createReferenceService,
    UpdateReferenceService updateReferenceService,
    GetAllReferenceValuesService getAllReferenceValuesService,
    GetReferenceValueService getReferenceValueService,
    CreateReferenceValueService createReferenceValueService,
    UpdateReferenceValueService updateReferenceValueService,
    UploadReferenceValueService uploadReferenceValueService,
    GetNewReferenceTypeIdService getNewReferenceTypeIdService,
    UsersService usersService)
    : ControllerBase
{
    [HttpPost(nameof(GetTypes), Name = nameof(GetTypes))]
    public async Task<GetReferencesTypesQueryBffResponse> GetTypes(GetReferencesTypesQueryBff query, CancellationToken cancellationToken)
    {
        var response = await getReferencesTypesService.Get(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetReferencesTypeValuesSearch), Name = nameof(GetReferencesTypeValuesSearch))]
    public async Task<GetReferencesTypeValuesSearchQueryBffResponse> GetReferencesTypeValuesSearch(
        GetReferencesTypeValuesSearchQueryBff query,
        CancellationToken cancellationToken)
    {
        var response = await getReferencesTypeValuesSearchService.Get(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetAllReferences))]
    public async Task<GetAllReferencesQueryResponseBff> GetAllReferences(GetAllReferencesQueryBff query, CancellationToken cancellationToken)
    {
        var response = await getAllReferencesService.GetAll(query, cancellationToken);

        return response;
    }

    [HttpPost(nameof(GetReference))]
    public async Task<GetReferenceQueryResponseBff> GetReference(GetReferenceQueryBff query, CancellationToken cancellationToken)
    {
        var result = await getReferenceService.Get(query, cancellationToken);

        return result;
    }

    [HttpPost(nameof(CreateReference))]
    public async Task<CreateReferenceCommandResponseBff> CreateReference([FromBody] CreateReferenceCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await createReferenceService.Create(command, user, cancellationToken);

        return result;
    }

    [HttpPut(nameof(UpdateReference))]
    public async Task<UpdateReferenceCommandResponseBff> UpdateReference([FromBody] UpdateReferenceCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await updateReferenceService.Update(command, user, cancellationToken);

        return result;
    }

    [HttpPost(nameof(GetAllReferenceValues))]
    public async Task<GetAllReferenceValuesQueryResponseBff> GetAllReferenceValues(GetAllReferenceValuesQueryBff query, CancellationToken cancellationToken)
    {
        var result = await getAllReferenceValuesService.Get(query, cancellationToken);

        return result;
    }

    [HttpPost(nameof(GetReferenceValue))]
    public async Task<GetReferenceValueQueryResponseBff> GetReferenceValue(GetReferenceValueQueryBff query, CancellationToken cancellationToken)
    {
        var result = await getReferenceValueService.Get(query, cancellationToken);

        return result;
    }

    [HttpPost(nameof(CreateReferenceValue))]
    public async Task<CreateReferenceValueCommandResponseBff> CreateReferenceValue([FromBody] CreateReferenceValueCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await createReferenceValueService.Create(command, user, cancellationToken);

        return result;
    }

    [HttpPut(nameof(UpdateReferenceValue))]
    public async Task<UpdateReferenceValueCommandResponseBff> UpdateReferenceValue([FromBody] UpdateReferenceValueCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await updateReferenceValueService.Update(command, user, cancellationToken);

        return result;
    }

    [HttpPost(nameof(UploadReferenceValues))]
    public async Task<UploadReferenceValueCommandResponseBff> UploadReferenceValues(UploadReferenceValuesCommandBff command, CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var result = await uploadReferenceValueService.Upload(command, user, cancellationToken);

        return result;
    }

    [HttpPost(nameof(GetNewReferenceTypeId))]
    public async Task<GetNewReferenceTypeIdQueryResponseBff> GetNewReferenceTypeId([FromBody] GetNewReferenceTypeIdQueryBff query, CancellationToken cancellationToken)
    {
        var result = await getNewReferenceTypeIdService.GetNewReferenceTypeId(query, cancellationToken);

        return result;
    }
}
