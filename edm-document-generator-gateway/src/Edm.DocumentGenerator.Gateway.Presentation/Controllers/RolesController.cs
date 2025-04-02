using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("roles")]
[ApiController]
[Authorize]
public class RolesController : ControllerBase
{
    private static readonly Dictionary<DocumentPermissionTypeBff, string> PermissionTypes = new Dictionary<DocumentPermissionTypeBff, string>
    {
        { DocumentPermissionTypeBff.Edit, "Редактирование" },
        { DocumentPermissionTypeBff.View, "Отображение" }
    };

    private static readonly Dictionary<DocumentPermissionTypeBff, string> PermissionTypesForStatus = new Dictionary<DocumentPermissionTypeBff, string>
    {
        { DocumentPermissionTypeBff.Edit, "Доступно" }
    };

    [HttpPost(nameof(GetPermissionTypes), Name = nameof(GetPermissionTypes))]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentPermissionTypeBff>>> GetPermissionTypes(CancellationToken cancellationToken)
    {
        var response = EnumMapBffConverter.ConvertToResponse(PermissionTypes);

        return Task.FromResult(response);
    }

    [HttpPost(nameof(GetPermissionTypesForStatus), Name = nameof(GetPermissionTypesForStatus))]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentPermissionTypeBff>>> GetPermissionTypesForStatus(CancellationToken cancellationToken)
    {
        var response = EnumMapBffConverter.ConvertToResponse(PermissionTypesForStatus);

        return Task.FromResult(response);
    }
}
