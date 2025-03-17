using Microsoft.AspNetCore.Http;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Upload.Contracts;

public sealed record UploadReferenceValuesCommandBff
{
    public required string DomainId { get; init; }
    public required string ReferenceType { get; init; }
    public required IFormFile File { get; init; }
}
