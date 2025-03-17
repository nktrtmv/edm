using Edm.Document.Searcher.Application.Documents.Events.DocumentGenerators.DocumentChanged.Contracts;
using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.Documents;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;
using Edm.Document.Searcher.Presentation.Consumers.DocumentGenerator.Events.Converters;
using Edm.DocumentGenerators.Presentation.Abstractions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Edm.Document.Searcher.Presentation.Controllers.Tech;

[ApiController]
[Route("api/tech/[action]")]
public sealed class TechController(
    ISearchDocumentsRepository searchDocumentsRepository,
    IDocumentsClient documentsClient,
    IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult?> GetDocumentFromDbById(string domainId, string id)
    {
        var domainIdValue = DomainId.Parse(domainId);
        var response = await searchDocumentsRepository.Get(domainIdValue, IdConverterFrom<SearchDocument>.FromString(id), CancellationToken.None);

        if (response == null)
        {
            return BadRequest("Document wasn't found");
        }

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetDocumentFromGeneratorById(string id)
    {
        var response = await documentsClient.Get(IdConverterFrom<DocumentExternal>.FromString(id), CancellationToken.None);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> ReloadDocumentById(string domainId, string id)
    {
        var request = new DocumentChangedDocumentGeneratorEventInternal(
            domainId,
            IdConverterFrom<SearchDocumentInternal>.FromString(id));
        await mediator.Send(request);

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> ProcessDocumentEvent([FromBody] object hexInput)
    {
        var bytes = ConvertHexStringToBytes(hexInput.ToString()!);

        var protoValue = DocumentGeneratorEventsValue.Parser.ParseFrom(bytes);
        var request = DocumentGeneratorEventsValueConverter.ToInternal(protoValue);

        await mediator.Send(request!, CancellationToken.None);

        return Ok();
    }

    private static byte[] ConvertHexStringToBytes(string hexString)
    {
        var result = hexString
            .Trim()
            .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(x => (byte)Convert.ToInt32(x, 16))
            .ToArray();

        return result;
    }
}
