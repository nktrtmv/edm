using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType;
using Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("documents-statuses-parameters")]
[ApiController]
[Authorize]
public class DocumentsStatusesParametersController : ControllerBase
{
    public DocumentsStatusesParametersController(GetDefaultDocumentsStatusesParametersByStatusTypeService getDefaultParametersByStatusTypeService)
    {
        GetDefaultParametersByStatusTypeService = getDefaultParametersByStatusTypeService;
    }

    private GetDefaultDocumentsStatusesParametersByStatusTypeService GetDefaultParametersByStatusTypeService { get; }

    [HttpPost(nameof(GetDefaultParametersByStatusType), Name = nameof(GetDefaultParametersByStatusType))]
    public async Task<GetDefaultDocumentsStatusesParametersByStatusTypeQueryBffResponse> GetDefaultParametersByStatusType(CancellationToken cancellationToken)
    {
        var response =
            await GetDefaultParametersByStatusTypeService.Get(cancellationToken);

        return response;
    }
}
