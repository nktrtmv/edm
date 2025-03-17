using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll;
using Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll.Contracts;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("system-attributes")]
[ApiController]
[Authorize]
public class DocumentSystemAttributesController(GetAllDocumentSystemAttributesService getAllService) : ControllerBase
{
    [HttpPost(nameof(GetAll), Name = nameof(GetAll))]
    public async Task<GetAllDocumentSystemAttributesQueryBffResponse> GetAll(
        GetAllDocumentSystemAttributesQueryBff query,
        CancellationToken cancellationToken)
    {
        var response = await getAllService.GetAll(query, cancellationToken);

        return response;
    }
}
