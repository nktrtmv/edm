using Edm.DocumentGenerator.Gateway.Core.Contracts.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsSystemAttributes.Queries.GetAll.Contracts;

public sealed class GetAllDocumentSystemAttributesQueryBffResponse
{
    public required DocumentAttributeBff[] Attributes { get; init; }
}
