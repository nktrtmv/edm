using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters.Inheritors.ByRoles.Inheritors.Strings;

public sealed class DocumentStringAttributeValueSelector(DocumentAttributeDocumentRole role)
    : DocumentAttributeValueByRoleSelectorGeneric<StringDocumentAttributeValue, DocumentStringAttribute, string>(role);
