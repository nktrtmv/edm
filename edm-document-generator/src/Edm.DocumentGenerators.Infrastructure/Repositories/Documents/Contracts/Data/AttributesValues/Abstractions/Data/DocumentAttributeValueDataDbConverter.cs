using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.AttributesValues.Abstractions.Data;

// TODO: REMOVE: This is for backward compatibility, remove in version 2.
internal static class DocumentAttributeValueDataDbConverter
{
    internal static DocumentAttribute ToDomain(DocumentAttributeValueDataDb data)
    {
        DocumentAttribute result = DocumentAttributeDbToDomainConverter.ToDomain(data.Attribute);

        return result;
    }
}
