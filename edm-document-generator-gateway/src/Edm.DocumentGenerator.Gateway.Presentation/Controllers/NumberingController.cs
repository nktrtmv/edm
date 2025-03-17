using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers;

[Route("numbering")]
[ApiController]
[Authorize]
public sealed class NumberingController : ControllerBase
{
    private static readonly Dictionary<DocumentNumberingSegmentTypeBff, string> SegmentTypes = new Dictionary<DocumentNumberingSegmentTypeBff, string>
    {
        { DocumentNumberingSegmentTypeBff.Constant, "Константа" },
        { DocumentNumberingSegmentTypeBff.Counter, "Счетчик" },
        { DocumentNumberingSegmentTypeBff.Date, "Дата" }
    };

    [HttpPost(nameof(GetSegmentTypes), Name = nameof(GetSegmentTypes))]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentNumberingSegmentTypeBff>>> GetSegmentTypes(CancellationToken cancellationToken)
    {
        CollectionQueryResponse<EnumMapBff<DocumentNumberingSegmentTypeBff>> response = EnumMapBffConverter.ConvertToResponse(SegmentTypes);

        return Task.FromResult(response);
    }
}
