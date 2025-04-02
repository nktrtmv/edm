using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get;
using Edm.DocumentGenerator.Gateway.Core.Domains;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("domains/[action]")]
[ApiController]
public sealed class DomainsController(GetAllDocumentDomainsService service) : ControllerBase
{
    [HttpPost]
    public async Task<GetDomainsQueryResponseBff> GetAllDomains(
        GetDomainsQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        var response = await service.GetAll(queryBff, cancellationToken);

        return response;
    }
}
